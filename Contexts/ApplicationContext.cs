using Java.Models;
using Microsoft.EntityFrameworkCore;

namespace Java.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<RentModel> Rents { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}