namespace QuoteRepo.Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(AuthorDto entity)
        {
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
            var authors = await _repository.GetAllAsync();
            return authors is null ? new DataResult<IList<AuthorDto>>(ResultStatus.Error, "Yazarlar bulunamadı.") : new DataResult<IList<AuthorDto>>(ResultStatus.Success, _mapper.Map<IList<AuthorDto>>(authors));
        }

        public async Task<IDataResult<AuthorDto>> GetAsync(int id)
        {
            var author = await _repository.GetAsync(a => a.Id == id);
            return author is null ? new DataResult<AuthorDto>(ResultStatus.Error, "Yazar bulunamadı.") : new DataResult<AuthorDto>(ResultStatus.Success, _mapper.Map<AuthorDto>(author));
        }

        public Task<IResult> UpdateAsync(AuthorDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
