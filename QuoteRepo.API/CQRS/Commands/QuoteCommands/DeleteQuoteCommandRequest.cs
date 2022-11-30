namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class DeleteQuoteCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }

        public DeleteQuoteCommandRequest(int id)
        {
            Id = id;
        }
    }
}
