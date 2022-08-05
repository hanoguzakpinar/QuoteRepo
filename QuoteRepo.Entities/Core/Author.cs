namespace QuoteRepo.Entities.Core
{
    public class Author
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Quote> Quotes { get; set; }
        public Author()
        {
            Country = new Country();
            Quotes = new List<Quote>();
        }
    }
}
