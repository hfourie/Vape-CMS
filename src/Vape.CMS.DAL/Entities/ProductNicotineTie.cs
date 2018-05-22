using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.Entities
{
    public class ProductNicotineTie
    {
        public int? ProductNicotineTieId { get; set; }
        public int ProductId { get; set; }
        public int NicotineId { get; set; }
        public double NicotineAmount { get; set; }
        public double NicotineDiscount { get; set; }
        public int NicotineStock { get; set; }
    }
}
