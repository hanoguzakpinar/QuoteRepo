namespace QuoteRepo.Business.Abstract
{
    public interface IAuthorService
    {
        Task<IDataResult<IList<AuthorDto>>> GetAllAsync();
        Task<IDataResult<AuthorDto>> GetAsync(int id);
        Task<IResult> CreateAsync(AuthorDto entity);
        Task<IResult> UpdateAsync(AuthorDto entity);
        Task<IResult> DeleteAsync(int id);
    }
}
