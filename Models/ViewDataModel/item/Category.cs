using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nextwo23.Models.ViewDataModel.item
{
    public class Category
    {
        [Key]
        public  Guid CategoryId { get; set; }
        [Required]
        public  string? CategoryName { get; set; }
        [Required]
        public  string? Description { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product = new Product();

    }
}
