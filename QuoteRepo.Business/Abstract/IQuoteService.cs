namespace QuoteRepo.Business.Abstract
{
    public interface IQuoteService
    {
        Task<IDataResult<IList<QuoteDto>>> GetAllAsync();
    }
}
