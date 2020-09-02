using System.Threading.Tasks;
using DomainModel;

namespace DomainService
{
    public interface IRegistrationService
    {
        Task<bool> Register(User user, Course course);
    }
}