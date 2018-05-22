using System;
using System.ComponentModel;

namespace Vape.CMS.DAL.Entities
{
    public class Size
    {
        public int? SizeId { get; set; }
        [DisplayName("Size Strength")]
        public int SizeDesc { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}