namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class CreateAuthorCommandRequest : IRequest<Result<CreateAuthorCommandRequest>>
    {
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}
