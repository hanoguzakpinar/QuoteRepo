using AutoMapper;
using MediatR;
using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, List<CountryDto>>
    {
        private readonly IRepository<Country> repository;
        private readonly IMapper mapper;
        //private readonly QuoteContext context;

        public GetAllCountriesQueryHandler(IRepository<Country> repository, IMapper mapper/*, QuoteContext context*/)
        {
            this.repository = repository;
            this.mapper = mapper;
            //this.context = context;
        }

        public async Task<List<CountryDto>> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            var countries = await repository.GetAllAsync(predicate: null, x => x.Authors);
            return mapper.Map<List<CountryDto>>(countries);

            /*var countries = await context.Countries.Include(c=>c.Authors).ThenInclude(x=> x.Quotes).ToListAsync();
            return mapper.Map<List<CountryDto>>(countries);*/ //include theninclude örneği
        }
    }
}
