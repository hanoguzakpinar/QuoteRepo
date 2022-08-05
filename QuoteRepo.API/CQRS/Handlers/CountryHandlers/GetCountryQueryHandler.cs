using AutoMapper;
using MediatR;
using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, CountryDto>
    {
        private readonly IRepository<Country> repository;
        private readonly IMapper mapper;

        public GetCountryQueryHandler(IRepository<Country> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CountryDto> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            var country = await repository.GetAsync(c => c.Id == request.Id);
            return mapper.Map<CountryDto>(country);
        }
    }
}
