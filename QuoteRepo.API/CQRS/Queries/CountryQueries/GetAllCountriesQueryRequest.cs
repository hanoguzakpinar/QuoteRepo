using MediatR;
using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetAllCountriesQueryRequest : IRequest<List<CountryDto>>
    {
    }
}
