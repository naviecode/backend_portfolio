using Portfolio.Models;
using Portfolio.ViewModel;

namespace Portfolio.Repositories
{
    public interface IProfileRepository
    {
        Task<Profile?> getById(int profileId);
        Task<bool> update(ProfileUpdVM profile);
    }
}
