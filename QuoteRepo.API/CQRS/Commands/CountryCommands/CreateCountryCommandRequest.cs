using MediatR;
using IResult = QuoteRepo.Shared.Results.IResult;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class CreateCountryCommandRequest : IRequest<IResult>
    {
        public string? Name { get; set; }
    }
}
