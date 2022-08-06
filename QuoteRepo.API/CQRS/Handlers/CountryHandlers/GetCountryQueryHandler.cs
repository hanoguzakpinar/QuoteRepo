using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, IDataResult<CountryDto>>
    {
        private readonly ICountryService _countryService;

        public GetCountryQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IDataResult<CountryDto>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            GetCountryQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new DataResult<CountryDto>(ResultStatus.Error, errors: valResult.Errors);

            return await _countryService.GetAsync(request.Id);
        }
    }
}
