using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nextwo23.Models.ViewDataModel.item;

namespace Nextwo23.Data
{

    public class Nextwo23_DBContext : IdentityDbContext
    {
        public Nextwo23_DBContext(DbContextOptions<Nextwo23_DBContext> options) : base(options)
        {

        }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
