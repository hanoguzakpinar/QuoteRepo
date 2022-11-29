namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class DeleteAuthorCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }
        public DeleteAuthorCommandRequest(int id)
        {
            Id = id;
        }
    }
}
