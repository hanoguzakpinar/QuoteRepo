using AutoMapper;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.Business.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CountryDto>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();
            return _mapper.Map<IList<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetAsync(int id)
        {
            var country = await _repository.GetAsync(c => c.Id == id);
            return _mapper.Map<CountryDto>(country);
        }
    }
}
