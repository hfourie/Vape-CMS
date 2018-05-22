using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
   public class ProductNicotineTieListDto
    {
        public int ProductNicotineTieId { get; set; }
        public int NicotineId { get; set; }
        public double Nicotine { get; set; }
        public double NicotineAmount { get; set; }
        public double NicotineDiscount { get; set; }
        public int NicotineStock { get; set; }
    }
}
