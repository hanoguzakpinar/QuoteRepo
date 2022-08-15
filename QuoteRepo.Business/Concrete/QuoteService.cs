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
            return quotes is null ? new DataResult<IList<QuoteDto>>(ResultStatus.Error, "Alıntı bulunamadı.") : new DataResult<IList<QuoteDto>>(ResultStatus.Success, _mapper.Map<IList<QuoteDto>>(quotes));
        }
    }
}
