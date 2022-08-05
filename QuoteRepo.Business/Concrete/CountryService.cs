using AutoMapper;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

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

        public async Task<IDataResult<IList<CountryDto>>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();
            if (countries is null) return new DataResult<IList<CountryDto>>(ResultStatus.Error, "Ülkeler bulunamadı.", null);
            return new DataResult<IList<CountryDto>>(ResultStatus.Success, _mapper.Map<IList<CountryDto>>(countries));
        }

        public async Task<IDataResult<CountryDto>> GetAsync(int id)
        {
            var country = await _repository.GetAsync(c => c.Id == id);
            if (country == null)
            {
                return new DataResult<CountryDto>(ResultStatus.Error, "Ülke bulunamadı.");
            }//burada success dönüyor?
            else
            {
                return new DataResult<CountryDto>(ResultStatus.Success, _mapper.Map<CountryDto>(country));
            }
        }
    }
}
