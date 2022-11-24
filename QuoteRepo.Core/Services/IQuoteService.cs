namespace QuoteRepo.Core.Services
{
    public interface IQuoteService
    {
        Task<IDataResult<IList<QuoteDto>>> GetAllAsync();
        Task<IDataResult<QuoteDto>> GetAsync(int id);
        Task<IResult> CreateAsync(CreateQuoteDto entity);
        Task<IResult> UpdateAsync(UpdateQuoteDto entity);
        Task<IResult> DeleteAsync(int id);
        Task<bool> AnyAsync(int id);
    }
}
