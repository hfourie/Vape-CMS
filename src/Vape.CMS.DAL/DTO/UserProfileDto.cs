using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
    public class UserProfileDto
    {
        public string UserGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? FileId { get; set; }
        [DisplayName("Role")]
        public int RoleId { get; set; }
    }
}
