using System.Threading.Tasks;
using DomainModel;
using DomainService;

namespace ApplicationService
{
    public class RegistrationService
    {
        private readonly IRegistrationService _registerService;

        public RegistrationService(IRegistrationService registerService)
        {
            _registerService = registerService;
        }

        public async Task<bool> Register(User user, Course course)
        {
            var a = new User(user.Id, user.Name);
            var b = new Course(course.Id, course.Name);
            return await _registerService.Register(a,b);
         
        }
    }
}