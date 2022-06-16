using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Ürün İsmi")]
        [Required(ErrorMessage ="Lütfen Ürün İsmi giriniz")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = "Lütfen Ürün Fiyatı giriniz")]
        public int ProductPrice { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        [Required(ErrorMessage = "Lütfen Ürün Açıklaması giriniz")]
        public string ProductDescription { get; set; }
        public string Resim { get; set; }
        [NotMapped]
        public IFormFile ProductFormFile { get; set; }
        public bool ProductIsActive { get; set; }
        public string ProductCreatedDate { get; set; } = DateTime.Now.ToString();

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
