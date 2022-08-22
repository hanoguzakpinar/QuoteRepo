namespace QuoteRepo.Business.Abstract
{
    public interface IQuoteService
    {
        Task<IDataResult<IList<QuoteDto>>> GetAllAsync();
        Task<IDataResult<QuoteDto>> GetAsync(int id);
    }
}
