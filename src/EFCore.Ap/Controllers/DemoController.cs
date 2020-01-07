using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Ap.Models;
using EFCore.Dal;
using EFCore.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCore.Ap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly MyDbContext dbcontext = null;
        public DemoController(MyDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] ApiUser user)
        {
            var matchedUser = 
                this.dbcontext.Set<User>().FirstOrDefault(x => x.Name.Equals(user.Name) && MyDbContext.DbHashMatch(user.Password, x.Password));
            if (matchedUser != null)
                return this.Ok();
            else
                return this.BadRequest();
        }

        [HttpGet("GetUser/{name}")]
        public async Task<User> GetUser([FromRoute] string name)
        {
            return this.dbcontext.Set<User>().FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
