using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextwoFinalApp.Models;

namespace NextwoFinalApp.Data
{
    public class FinalDbContext :IdentityDbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) :base(options)
        {
            
        }
        public DbSet<Blog>Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Partner> partners { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Setting> settings { get; set; }
        public DbSet<Slider> sliders { get; set; }










    }
}
