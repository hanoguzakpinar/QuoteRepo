using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Business.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(IRepository<Country> repository, IUnitOfWork unitOfWork, ICountryRepository countryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<Result<CountryWithAuthorsDto>> GetCountryWithAuthors(int categoryId)
        {
            var country = await _countryRepository.GetCountryWithAuthors(categoryId);
            return Result<CountryWithAuthorsDto>.Success(200,
                _mapper.Map<CountryWithAuthorsDto>(country));
        }
    }
}
