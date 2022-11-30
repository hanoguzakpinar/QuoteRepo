namespace QuoteRepo.Core.DTOs
{
    public class QuoteDto : BaseDto
    {
        public string? Text { get; set; }
        public int AuthorId { get; set; }
    }
}
