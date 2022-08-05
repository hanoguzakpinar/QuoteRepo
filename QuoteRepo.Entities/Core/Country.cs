namespace QuoteRepo.Entities.Core
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Author> Authors { get; set; }
        public Country()
        {
            Authors = new List<Author>();
        }
    }
}
