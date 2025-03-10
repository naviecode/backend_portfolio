using Microsoft.AspNetCore.Mvc;
using Portfolio.Filters;

namespace Portfolio.Attribute
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
        {
        }
    }
}
