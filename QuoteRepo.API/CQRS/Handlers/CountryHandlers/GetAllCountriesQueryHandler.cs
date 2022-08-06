using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, IDataResult<IList<CountryDto>>>
    {
        private readonly ICountryService _countryService;

        public GetAllCountriesQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IDataResult<IList<CountryDto>>> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _countryService.GetAllAsync();
        }
    }
}
