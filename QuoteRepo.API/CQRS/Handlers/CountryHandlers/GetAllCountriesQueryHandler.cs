using AutoMapper;
using MediatR;
using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, IDataResult<IList<CountryDto>>>
    {
        private readonly IRepository<Country> repository;
        private readonly ICountryService countryService;
        private readonly IMapper mapper;
        //private readonly QuoteContext context;

        public GetAllCountriesQueryHandler(IRepository<Country> repository, IMapper mapper, ICountryService countryService/*, QuoteContext context*/)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryService = countryService;
            //this.context = context;
        }

        public async Task<IDataResult<IList<CountryDto>>> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            var countries = await countryService.GetAllAsync();
            return countries.ResultStatus == ResultStatus.Error ? new DataResult<IList<CountryDto>>(ResultStatus.Error, message: countries.Message) : new DataResult<IList<CountryDto>>(data: countries.Data);

            /*var countries = await context.Countries.Include(c=>c.Authors).ThenInclude(x=> x.Quotes).ToListAsync();
            return mapper.Map<List<CountryDto>>(countries);*/ //include theninclude örneği
        }
    }
}
