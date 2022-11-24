using QuoteRepo.Core.Models;

namespace QuoteRepo.Data.Concrete.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.FullName).IsRequired().HasMaxLength(50);

            builder.HasOne(a => a.Country).WithMany(c => c.Authors).HasForeignKey(a => a.CountryId);
            builder.HasMany(a => a.Quotes).WithOne(c => c.Author).HasForeignKey(a => a.AuthorId);

            builder.ToTable("Authors");

            //builder.HasData(GetAuthors());
        }

        private static IList<Author> GetAuthors()
        {
            var authors = new List<Author>
            {
                new Author { Id = 1, FullName = "Alexandre Dumas", BirthDate = new DateTime(1802, 07, 24), CountryId = 3 },
                new Author { Id = 2, FullName = "Stefan Zweig", BirthDate = new DateTime(1881, 11, 28), CountryId = 6 }
            };

            return authors;
        }
    }
}
