using QuoteRepo.Core.Services;
using System.Collections.Generic;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, Result<IList<CountryDto>>>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<IList<CountryDto>>> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await _countryService.GetAllAsync();
            var mapped = _mapper.Map<IList<CountryDto>>(datas);
            return Result<IList<CountryDto>>.Success(200, mapped);
        }
    }
}
