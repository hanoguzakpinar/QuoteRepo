namespace QuoteRepo.Core.Models
{
    public class Quote : BaseEntity
    {
        public string? Text { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
