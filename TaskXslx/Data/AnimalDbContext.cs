using Microsoft.EntityFrameworkCore;
using TaskXslx.Entities;

namespace TaskXslx.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions options)
        : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

    }
}
