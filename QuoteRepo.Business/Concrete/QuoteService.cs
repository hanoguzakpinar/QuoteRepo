namespace QuoteRepo.Business.Concrete
{
    public class QuoteService : IQuoteService
    {
        private readonly IRepository<Quote> _repository;
        private readonly IMapper _mapper;

        public QuoteService(IRepository<Quote> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
    }
}
