using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCreatedDate { get; set; } = DateTime.Now.ToString();
    }
}
