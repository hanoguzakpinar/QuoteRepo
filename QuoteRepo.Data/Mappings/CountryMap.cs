namespace QuoteRepo.Data.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Authors).WithOne(a => a.Country).HasForeignKey(c => c.CountryId);

            builder.ToTable("Countries");

            builder.HasData(GetCountries());
        }

        private static IList<Country> GetCountries()
        {
            var countryList = new List<Country>
            {
                new Country { Id = 1, Name = "Turkey" },
                new Country { Id = 2, Name = "England" },
                new Country { Id = 3, Name = "France" },
                new Country { Id = 4, Name = "Spain" },
                new Country { Id = 5, Name = "Germany" },
                new Country { Id = 6, Name = "Austria" },
                new Country { Id = 7, Name = "Japan" },
                new Country { Id = 8, Name = "Korea" },
                new Country { Id = 9, Name = "United States" },
                new Country { Id = 10, Name = "Greece" }
            };
            return countryList;
        }
    }
}
