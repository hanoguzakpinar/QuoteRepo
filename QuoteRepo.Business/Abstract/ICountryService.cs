global using AutoMapper;
global using QuoteRepo.Business.Abstract;
global using QuoteRepo.Data.Abstract.Repositories;
global using QuoteRepo.Entities.Core;
global using QuoteRepo.Entities.Dtos;
global using QuoteRepo.Shared.Results;

namespace QuoteRepo.Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<IList<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetAsync(int id);
        Task<IResult> CreateAsync(CountryDto entity);
        Task<IResult> DeleteAsync(int id);
    }
}
