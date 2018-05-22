using System;

namespace Vape.CMS.DAL.Entities
{
    public class UserProductReview
    {
        public int UserProductReviewId { get; set; }
        public int ProductId { get; set; }
        public int ReviewId { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}