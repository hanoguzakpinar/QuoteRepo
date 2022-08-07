﻿namespace QuoteRepo.Business.Concrete
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
            return countries is null ? new DataResult<IList<CountryDto>>(ResultStatus.Error, "Ülkeler bulunamadı.") : new DataResult<IList<CountryDto>>(ResultStatus.Success, _mapper.Map<IList<CountryDto>>(countries));
        }

        public async Task<IDataResult<CountryDto>> GetAsync(int id)
        {
            var country = await _repository.GetAsync(c => c.Id == id);
            return country is null
                ? new DataResult<CountryDto>(ResultStatus.Error, "Ülke bulunamadı.") :
                  new DataResult<CountryDto>(ResultStatus.Success, _mapper.Map<CountryDto>(country));
        }

        public async Task<IResult> CreateAsync(CountryDto entity)
        {
            await _repository.AddAsync(_mapper.Map<Country>(entity));
            return new Result(ResultStatus.Success, $"{entity.Name} eklendi.");
        }

        public async Task<IResult> UpdateAsync(CountryDto entity)
        {
            var country = await _repository.AnyAsync(c => c.Id == entity.Id);
            if (country is false) return new Result(ResultStatus.Error, "Ülke bulunamadı.");

            await _repository.UpdateAsync(_mapper.Map<Country>(entity));
            return new Result(ResultStatus.Success, $"{entity.Name} güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var country = await _repository.GetAsync(c => c.Id == id);
            if (country is null) return new Result(ResultStatus.Error, "Ülke bulunamadı.");

            await _repository.DeleteAsync(country);
            return new Result(ResultStatus.Success, $"{country.Name} silindi.");
        }
    }
}
