using Guide.TesteVaga.Models;
using Microsoft.EntityFrameworkCore;

namespace Guide.TesteVaga.Context
{
    public class NomesDbContext : DbContext
    {
        public NomesDbContext(DbContextOptions<NomesDbContext> options) : base(options)
        { }

        public DbSet<Nomes> Nomes { get; set; }
    }
}