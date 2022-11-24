using QuoteRepo.Core.Models;

namespace QuoteRepo.Data.Concrete.Mappings
{
    public class QuoteMap : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();

            builder.Property(q => q.Text).IsRequired().HasColumnType("NVARCHAR(MAX)");

            builder.HasOne(c => c.Author).WithMany(a => a.Quotes).HasForeignKey(c => c.AuthorId);

            builder.ToTable("Quotes");

            //builder.HasData(GetQuotes());
        }

        private static IList<Quote> GetQuotes()
        {
            var quotes = new List<Quote>
            {
                new Quote { Id = 1, AuthorId = 1, Text = "Dantes vs Mercedes" }
            };
            return quotes;
        }
    }
}
