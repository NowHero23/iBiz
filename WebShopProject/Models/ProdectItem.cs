using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopProject.Models
{
    public class ProdectItem
    {
        public int Id { get; set; } //Url
        public string Name { get; set; } //Назва товару
        public double Price { get; set; } //Ціна
        public string Currency { get; set; } //Валюта temp

        [StringLength(10000)]
        public string Description { get; set; } //html

        public int State { get; set; } //Стан товару
        public int Conditions { get; set; } //Умови придбання

        public DateTime PublicationDate { get; set; } //Дата публікації


        public int ManufactureId { get; set; } // Id втробника
        public int? LocationId { get; set; } // Id локація /область/район
        public int CategoryId { get; set; } //Категорія

        [DefaultValue(0)]
        public int ViewsCount { get; set; } //кількість переглядів
    }
}
