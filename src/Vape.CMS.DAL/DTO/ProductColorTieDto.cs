namespace Vape.CMS.DAL.DTO
{
    public class ProductColorTieDto
    {
        public int? ProductColorTieId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public double ColorAmount { get; set; }
        public double ColorDiscount { get; set; }
        public int ColorStock { get; set; }
    }
}
