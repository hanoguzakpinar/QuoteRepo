namespace QuoteRepo.Core.DTOs
{
    public class CreateQuoteDto
    {
        public string? Text { get; set; }
        public int AuthorId { get; set; }
    }
}
