namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class CreateQuoteCommandRequest : IRequest<IResult>
    {
        public string? Text { get; set; }
        public int AuthorId { get; set; }
    }
}
