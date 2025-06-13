using CatFacts.Models;
using Microsoft.EntityFrameworkCore;

namespace CatFacts.Data
{

    public class CatContext : DbContext
    {

        public CatContext(DbContextOptions<CatContext> opt) : base(opt)
        {

        }
        
        public DbSet<Cat> Cats { get; set; }
    }
}