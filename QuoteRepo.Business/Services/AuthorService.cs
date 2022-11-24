namespace QuoteRepo.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> repository, IMapper mapper, IRepository<Country> countryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<IResult> CreateAsync(CreateAuthorDto entity)
        {
            if (!await _countryRepository.AnyAsync(c => c.Id == entity.CountryId))
                return new Result(ResultStatus.Error, "CountryId veritabanında kayıtlı değil.");

            await _repository.AddAsync(_mapper.Map<Author>(entity));
            return new Result(ResultStatus.Success, $"{entity.FullName} eklendi.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var author = await _repository.GetAsync(a => a.Id == id);
            if (author is null) return new Result(ResultStatus.Error, "Yazar bulunamadı.");

            await _repository.DeleteAsync(author);
            return new Result(ResultStatus.Success, $"{author.FullName} silindi.");
        }

        public async Task<IDataResult<IList<AuthorDto>>> GetAllAsync()
        {
            var authors = await _repository.GetAllAsync(null, a => a.Country);
            return authors is null ? new DataResult<IList<AuthorDto>>(ResultStatus.Error, "Yazarlar bulunamadı.") : new DataResult<IList<AuthorDto>>(ResultStatus.Success, _mapper.Map<IList<AuthorDto>>(authors));
        }

        public async Task<IDataResult<AuthorDto>> GetAsync(int id)
        {
            var author = await _repository.GetAsync(a => a.Id == id, a => a.Country);
            return author is null ? new DataResult<AuthorDto>(ResultStatus.Error, "Yazar bulunamadı.") : new DataResult<AuthorDto>(ResultStatus.Success, _mapper.Map<AuthorDto>(author));
        }

        public async Task<IResult> UpdateAsync(UpdateAuthorDto entity)
        {
            if (!await AnyAsync(entity.Id)) return new Result(ResultStatus.Error, "Yazar bulunamadı.");

            if (!await _countryRepository.AnyAsync(c => c.Id == entity.CountryId))
                return new Result(ResultStatus.Error, "CountryId veritabanında kayıtlı değil.");

            await _repository.UpdateAsync(_mapper.Map<Author>(entity));
            return new Result(ResultStatus.Success, $"{entity.FullName} güncellendi.");
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _repository.AnyAsync(c => c.Id == id);
        }
    }
}
