namespace WebShopProject.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public string ImgAlt { get; set; }
        public int CategoryId { get; set; }
    }
}
