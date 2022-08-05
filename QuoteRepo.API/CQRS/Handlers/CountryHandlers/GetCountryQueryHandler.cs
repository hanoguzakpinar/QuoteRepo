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
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, IDataResult<CountryDto>>
    {
        private readonly IRepository<Country> repository;
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public GetCountryQueryHandler(IRepository<Country> repository, IMapper mapper, ICountryService countryService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryService = countryService;
        }

        public async Task<IDataResult<CountryDto>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            GetCountryQueryValidator validator = new();
            var valResult = validator.Validate(request);
            if (valResult.Errors.Count > 0)
                return new DataResult<CountryDto>(ResultStatus.Error, errors: valResult.Errors);

            return await countryService.GetAsync(request.Id);
        }
    }
}
