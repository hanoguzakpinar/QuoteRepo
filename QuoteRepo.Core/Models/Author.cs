namespace QuoteRepo.Core.Models
{
    public class Author : BaseEntity
    {
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Quote> Quotes { get; set; }
        public Author()
        {
            Quotes = new List<Quote>();
        }
    }
}
