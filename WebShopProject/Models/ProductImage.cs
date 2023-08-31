namespace WebShopProject.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SrcPath { get; set; }
        public string Alt { get; set; }
    }
}
