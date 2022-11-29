namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class UpdateCountryCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
