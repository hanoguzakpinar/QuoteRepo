using MediatR;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class DeleteCountryCommandRequest : IRequest<IDataResult<CountryDto>>
    {
        public int Id { get; set; }
        public DeleteCountryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
