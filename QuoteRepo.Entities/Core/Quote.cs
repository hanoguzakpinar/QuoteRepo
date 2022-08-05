namespace QuoteRepo.Entities.Core
{
    public class Quote
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Quote()
        {
            Author = new Author();
        }
    }
}
