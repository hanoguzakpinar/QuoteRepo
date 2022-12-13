namespace QuoteRepo.Core.DTOs
{
    public class AuthorWithQuotesDto : AuthorDto
    {
        public List<QuoteDto> Quotes { get; set; }
    }
}
