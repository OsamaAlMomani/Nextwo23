using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nextwo23.Models.ViewDataModel.item
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        
        [Required]
        public string? ProductType { get; set;}
        [Required]
        public float? ProductPrice { get; set;}
        
        
        public string? ProductIMG { get; set;}
        
    }
}
