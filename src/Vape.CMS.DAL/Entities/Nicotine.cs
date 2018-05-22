using System;
using System.ComponentModel;

namespace Vape.CMS.DAL.Entities
{
    public class Nicotine
    {
        public int? NicotineId { get; set; }
        [DisplayName("Nicotine Strength")]
        public int NicotineStrength { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}