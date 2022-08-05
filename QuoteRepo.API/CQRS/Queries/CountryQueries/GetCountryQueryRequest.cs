using MediatR;
using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetCountryQueryRequest : IRequest<CountryDto>
    {
        public int Id { get; set; }
        public GetCountryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
