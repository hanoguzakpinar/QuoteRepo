using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Business.Services
{
    public class AuthorService : Service<Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> repository, IUnitOfWork unitOfWork, IAuthorRepository authorRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Result<AuthorWithQuotesDto>> GetAuthorWithQuotes(int authorId)
        {
            var author = await _authorRepository.GetAuthorWithQuotes(authorId);
            return Result<AuthorWithQuotesDto>.Success(200, _mapper.Map<AuthorWithQuotesDto>(author));
        }
    }
}
