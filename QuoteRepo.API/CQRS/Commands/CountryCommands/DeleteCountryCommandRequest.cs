using MediatR;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;
using IResult = QuoteRepo.Shared.Results.IResult;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class DeleteCountryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public DeleteCountryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
