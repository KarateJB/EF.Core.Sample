using System;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Ap.Models;
using EFCore.Core.Models;
using EFCore.Dal;
using EFCore.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCore.Ap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly PgDbContext dbcontext = null;
        public DemoController(PgDbContext dbcontext, IOptions<AppSettings> configuration)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] ApiUser user)
        {
            var matchedUser =
                this.dbcontext.Set<User>().FirstOrDefault(x => x.Name.Equals(user.Name) && PgDbContext.DbHashMatch(user.Password, x.Password));
            if (matchedUser != null)
                return this.Ok();
            else
                return this.BadRequest();
        }

        [HttpGet("GetUser/{name}")]
        public async Task<ApiUserInfo> GetUser([FromRoute] string name)
        {
            return this.dbcontext.Set<User>().Include(u => u.Metadata).Where(x => x.Name.Equals(name)).Select(x =>
                new ApiUserInfo
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    CardNo = x.CardNo,
                    Secret = PgDbContext.DbSymDecrypt(x.Secret),
                    Metadata = x.Metadata
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
                Secret = PgDbContext.DbSymEncrypt("some secret"),
                Metadata = new SysMetadata
                {
                    CreateBy = "Admin",
                    CreateOn = DateTimeOffset.UtcNow
                }
            }).First());
            await this.dbcontext.SaveChangesAsync();
            return this.Ok();
        }
    }
}
