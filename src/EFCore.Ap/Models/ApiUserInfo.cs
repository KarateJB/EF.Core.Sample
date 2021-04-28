using EFCore.Dal.Models;

namespace EFCore.Ap.Models
{
    public class ApiUserInfo
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CardNo { get; set; }
        public string Secret { get; set; }

        public SysMetadata Metadata { get; set; }
    }
}
