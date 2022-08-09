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

        public Task<IResult> CreateAsync(AuthorDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<AuthorDto>>> GetAllAsync()
        {
            var authors = await _repository.GetAllAsync();
            return authors is null ? new DataResult<IList<AuthorDto>>(ResultStatus.Error, "Yazarlar bulunamadı.") : new DataResult<IList<AuthorDto>>(ResultStatus.Success, _mapper.Map<IList<AuthorDto>>(authors));
        }

        public Task<IDataResult<AuthorDto>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(AuthorDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
