using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.WebApi.Models;
using MySchool.WebApi.ViewModels;
using System.Linq;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MySchoolContext dbContext;

        public AuthController()
        {
            dbContext = new MySchoolContext();
        }

        [HttpPost("login")]
        public LoginResponseModel Post(LoginModel loginModel)
        {
            var user = dbContext.Users
                .Include(x => x.Role)
                .Where(x => x.Username == loginModel.Username && x.Password == loginModel.Password && x.IsActive)
                .FirstOrDefault();

            if (user == null)
                return null;
            else
            {
                return new LoginResponseModel
                {
                    UserName = user.Username,
                    UserRole = user.Role.Name
                };
            }
        }
    }
}
