namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class UpdateQuoteCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int AuthorId { get; set; }
    }
}
