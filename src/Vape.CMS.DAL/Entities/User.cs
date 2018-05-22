using System;

namespace Vape.CMS.DAL.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool ValidEmail { get; set; }
        public DateTime LastActive { get; set; }
        public bool ContactViaEmail { get; set; }
        public int? ProfilePictureId { get; set; }
        public bool Deleted { get; set; }
    }
}