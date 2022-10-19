using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruiment.IBusiness.DTO;
using Sat.Recruiment.IBusiness;
using Sat.Recruiment.Business;
using Sat.Recruiment.Business.DTO;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {        
        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        public Task<IResultDto> CreateUser(UserDto newUser)
        {
            return new UserBusiness().CreateUser(newUser);
        }
    }
}
