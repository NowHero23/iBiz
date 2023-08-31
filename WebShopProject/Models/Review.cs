namespace WebShopProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; } //1-5 кількість зірок

        public int ProdectId { get; set; } //ProdectItem
        public int SellerId { get; set; } //User
        public int CustomerId { get; set; } //User
        public string? Comment { get; set; }
        public DateTime PublicationDate { get; set; } //Дата публікації
    }
}
