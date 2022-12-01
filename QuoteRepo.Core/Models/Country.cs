namespace QuoteRepo.Core.Models
{
    public class Country : BaseEntity
    {
        public string? Name { get; set; }
        public List<Author> Authors { get; set; }
        public Country()
        {
            Authors = new List<Author>();
        }
    }
}
