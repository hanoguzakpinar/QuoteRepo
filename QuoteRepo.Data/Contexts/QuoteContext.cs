using System.Reflection;

namespace QuoteRepo.Data.Contexts
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {
        }
        public DbSet<AppRole> AppRoles => Set<AppRole>();
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Quote> Quotes => Set<Quote>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
