using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
    public class ProductsListDto
    {
        public string ProductGuId { get; set; }
        public string Product { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public string Discription { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public int Deleted { get; set; }
    }
}
