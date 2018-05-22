namespace Vape.CMS.DAL.Entities
{
    public class UserProductRating
    {
        public int UserProductRatingId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
    }
}