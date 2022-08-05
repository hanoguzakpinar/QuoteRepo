using MediatR;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class DeleteCountryCommandRequest : IRequest<Result>
    {
        public int Id { get; set; }
        public DeleteCountryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
