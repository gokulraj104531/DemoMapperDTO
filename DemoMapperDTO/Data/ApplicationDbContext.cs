using DemoMapperDTO.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMapperDTO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserRegisteration> userRegisterations { get; set; }
    }
}
