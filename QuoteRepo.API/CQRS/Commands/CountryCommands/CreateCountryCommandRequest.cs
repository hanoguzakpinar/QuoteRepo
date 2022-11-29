namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class CreateCountryCommandRequest : IRequest<Result<CreateCountryCommandRequest>>//Result<CountryDto> olarak değiştirilebilir.
    {
        public string? Name { get; set; }
    }
}
