using System;
using System.ComponentModel;

namespace Vape.CMS.DAL.Entities
{
    public class Color
    {
        public int? ColorId { get; set; }
        [DisplayName("Color Description")]
        public string ColorDesc { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}