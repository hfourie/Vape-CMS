using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
    public class UsersListDto
    {
        public string UserGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime LastActive { get; set; }
        public bool ContactViaEmail { get; set; }
    }
}
