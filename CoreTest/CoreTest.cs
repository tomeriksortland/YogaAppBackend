using System.Threading.Tasks;
using ApplicationService;
using DomainModel;
using DomainService;
using Moq;
using NUnit.Framework;

namespace CoreTest
{
    public class Tests
    {
        [Test]
        public async Task CoreTest()
        {
            var registrationServiceMock = new Mock<IRegistrationService>();
            registrationServiceMock
                .Setup(r => r
                    .Register(It.IsAny<User>(), It.IsAny<Course>()))
                .ReturnsAsync(true);
            
            var service = new RegistrationService(registrationServiceMock.Object);
            
            var a = new User(1, "Tom Erik");
            var b = new Course(1 , "Yoga");
            
            var test = await service.Register(a, b);
            
            Assert.IsTrue(test);
            registrationServiceMock
                .Verify(r=>r
                    .Register(It.Is<User>(u=>u.Name == "Tom Erik"),It.Is<Course>(c=>c.Name == "Yoga")));
            registrationServiceMock.VerifyNoOtherCalls();
        }
    }
}