using System;
using System.ComponentModel;

namespace Vape.CMS.DAL.Entities
{
    public class Category
    {
        public int? CategoryId { get; set; }
        [DisplayName("Category Description")]
        public string CategoryDesc { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public bool Deleted { get; set; }

    }
}