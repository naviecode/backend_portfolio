using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Models;
using Portfolio.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PortfolioDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserRepository(PortfolioDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginVM loginVM)
        {
            var parameters = new[]
            {
                new SqlParameter("@password", loginVM.Password),
                new SqlParameter("@email", loginVM.Email)
            };
            IEnumerable<User?> result = await _dbContext.Users.FromSqlRaw("EXECUTE dbo.CheckLogin @email, @password", parameters).ToListAsync();

            User? user = result.FirstOrDefault();
            if(user != null)
            {
                string jwt = CreateToken(user.Id);

                //Refresh Token
                //Kiểm tra đã tồn tại refreshToken ở thiết bị này chưa thực hiện update hoặc ins
                
                RefreshToken refreshToken = new RefreshToken
                {
                    UserId = user.Id,
                    DeviceId = 1,
                    Token = CreateToken(user.Id),
                    ExpiryDate = DateTime.UtcNow.AddDays(30)
                };

                await _dbContext.RefreshTokens.AddAsync(refreshToken);
                await _dbContext.SaveChangesAsync();

                return jwt;
            }
            else
            {
                throw new Exception("Invalid email or password");
            }

        }

        public async Task<string> Logout(LogoutVM logoutVM)
        {
            var token = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x =>
                                     x.Token == logoutVM.Token &&
                                     x.DeviceId == logoutVM.DeviceId);
            if (token != null)
            {
                _dbContext.RefreshTokens.Remove(token);
                await _dbContext.SaveChangesAsync();
                return "Logged out sucessfully";
            }
            else
            {
                throw new Exception("Invalid token");
            }
        }

        public async Task<string> LogoutAllDevice(int userId)
        {
            return "Logged out all sucessfully";
        }

        public async Task<string> RefreshToken(RefreshVM refreshVM)
        {
            var refreshToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x =>
                                     x.Token == refreshVM.Token &&
                                     x.DeviceId == refreshVM.DeviceId &&
                                     x.ExpiryDate > DateTime.UtcNow);

            if (refreshToken == null)
            {
                throw new Exception("Invalid token");
            }

            var newAccessToken = CreateToken(refreshToken.UserId);
            return newAccessToken;
        }
        private string CreateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"] ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim(ClaimTypes.Name, userId.ToString())
                   }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
