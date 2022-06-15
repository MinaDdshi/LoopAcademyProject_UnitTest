using LoopAcademyProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoopAcademyProject.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
