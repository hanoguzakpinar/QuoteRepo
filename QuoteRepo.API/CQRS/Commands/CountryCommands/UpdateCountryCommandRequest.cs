namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class UpdateCountryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
