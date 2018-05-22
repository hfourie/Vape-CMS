using System;

namespace Vape.CMS.DAL.Entities
{
    public class Product
    {
        public int? ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductGuid { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
        public int UseridUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}