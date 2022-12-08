namespace QuoteRepo.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(QuoteContext context) : base(context)
        {
        }

        public async Task<Country> GetCountryWithAuthors(int countryId)
        {
            return await _context.Countries.Include(c => c.Authors).SingleOrDefaultAsync(c => c.Id == countryId);
        }
    }
}
