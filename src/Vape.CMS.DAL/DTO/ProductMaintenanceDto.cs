using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
    public class ProductMaintenanceDto
    {
        public int? ProductId { get; set; }
        public string Product { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public string Discription { get; set; }
        public ProductColorTieDto ProductColorTieDto { get; set; }
        public ProductNicotineTieDto ProductNicotineTieDto { get; set; }
        public ProductSizeTieDto ProductSizeTieDto { get; set; }
    }
}
