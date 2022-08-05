using MediatR;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class CreateCountryCommandRequest : IRequest
    {
        public string? Name { get; set; }
    }
}
