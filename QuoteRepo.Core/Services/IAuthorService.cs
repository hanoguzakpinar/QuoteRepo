namespace QuoteRepo.Core.Services
{
    public interface IAuthorService
    {
        Task<IDataResult<IList<AuthorDto>>> GetAllAsync();
        Task<IDataResult<AuthorDto>> GetAsync(int id);
        Task<IResult> CreateAsync(CreateAuthorDto entity);
        Task<IResult> UpdateAsync(UpdateAuthorDto entity);
        Task<IResult> DeleteAsync(int id);
        Task<bool> AnyAsync(int id);
    }
}
