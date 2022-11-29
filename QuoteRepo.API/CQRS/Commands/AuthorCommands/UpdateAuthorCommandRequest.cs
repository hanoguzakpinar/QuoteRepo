namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class UpdateAuthorCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}
