using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    /*public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, Result<CountryDto>>
    {
        private readonly ICountryService _countryService;

        public GetCountryQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Result<CountryDto>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            GetCountryQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return Result<CountryDto>.Fail(404, "XXX");

            return await _countryService.GetAsync(request.Id);
        }
    }*/
}
