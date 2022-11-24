namespace QuoteRepo.Core.DTOs
{
    public class CreateQuoteDto
    {
        //public int Id { get; set; }
        public string? Text { get; set; }
        public int AuthorId { get; set; }
    }
}
