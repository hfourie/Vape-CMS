using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.DTO
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public ProductColorTie ProductColorTie { get; set; }
        public ProductNicotineTie ProductNicotineTie { get; set; }
        public ProductSizeTie ProductSizeTie { get; set; }
    }
}
