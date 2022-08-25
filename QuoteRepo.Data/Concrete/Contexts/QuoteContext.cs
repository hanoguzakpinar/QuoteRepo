using QuoteRepo.Data.Concrete.Mappings;

namespace QuoteRepo.Data.Concrete.Contexts
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
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new QuoteMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
        }
    }
}
