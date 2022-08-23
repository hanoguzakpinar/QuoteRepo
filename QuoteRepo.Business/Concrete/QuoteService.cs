namespace QuoteRepo.Business.Concrete
{
    public class QuoteService : IQuoteService
    {
        private readonly IRepository<Quote> _repository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public QuoteService(IRepository<Quote> repository, IMapper mapper, IRepository<Author> authorRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _repository.AnyAsync(q => q.Id == id);
        }

        public async Task<IResult> CreateAsync(CreateQuoteDto entity)
        {
            if (!await _authorRepository.AnyAsync(a => a.Id == entity.AuthorId))
                return new Result(ResultStatus.Error, "AuthorId veritabanında kayıtlı değil.");

            await _repository.AddAsync(_mapper.Map<Quote>(entity));
            return new Result(ResultStatus.Success, $"Kayıt Başarılı.");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var quote = await _repository.GetAsync(q => q.Id == id);
            if (quote is null) return new Result(ResultStatus.Error, "Alıntı bulunamadı.");

            await _repository.DeleteAsync(quote);
            return new Result(ResultStatus.Success, $"{quote.Id} idli alıntı silindi.");
        }

        public async Task<IDataResult<IList<QuoteDto>>> GetAllAsync()
        {
            var quotes = await _repository.GetAllAsync();
            return quotes is null ? new DataResult<IList<QuoteDto>>(ResultStatus.Error, "Alıntılar bulunamadı.") : new DataResult<IList<QuoteDto>>(ResultStatus.Success, _mapper.Map<IList<QuoteDto>>(quotes));
        }

        public async Task<IDataResult<QuoteDto>> GetAsync(int id)
        {
            var quote = await _repository.GetAsync(q => q.Id == id);
            return quote is null ? new DataResult<QuoteDto>(ResultStatus.Error, "Alıntı bulunamadı.") : new DataResult<QuoteDto>(ResultStatus.Success, _mapper.Map<QuoteDto>(quote));
        }

        public async Task<IResult> UpdateAsync(UpdateQuoteDto entity)
        {
            if (!await AnyAsync(entity.Id)) return new Result(ResultStatus.Error, "Alıntı bulunamadı.");

            if (!await _authorRepository.AnyAsync(a => a.Id == entity.AuthorId))
                return new Result(ResultStatus.Error, "AuthorId veritabanında kayıtlı değil.");

            await _repository.UpdateAsync(_mapper.Map<Quote>(entity));
            return new Result(ResultStatus.Success, $"{entity.Id} güncellendi.");
        }
    }
}
