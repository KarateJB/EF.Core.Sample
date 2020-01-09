﻿using System.Linq;
using System.Threading.Tasks;
using EFCore.Ap.Models;
using EFCore.Core.Models;
using EFCore.Dal;
using EFCore.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EFCore.Ap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly MyDbContext dbcontext = null;
        public DemoController(MyDbContext dbcontext, IOptions<AppSettings> configuration)
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
        public async Task<ApiUserInfo> GetUser([FromRoute] string name)
        {
            return this.dbcontext.Set<User>().Where(x => x.Name.Equals(name)).Select(x=>
                new ApiUserInfo
                 { 
                    Name = x.Name,
                    Phone = x.Phone,
                    CardNo = x.CardNo,
                    Secret = MyDbContext.DbSymDecrypt(x.Secret)
                }).FirstOrDefault();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await this.dbcontext.Set<User>().AddAsync(this.dbcontext.Set<User>().Select(x => new User
            {
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                CardNo = user.CardNo,
                Secret = MyDbContext.DbSymEncrypt("some secret")
            }).First());
            await this.dbcontext.SaveChangesAsync();
            return this.Ok();
        }
    }
}
