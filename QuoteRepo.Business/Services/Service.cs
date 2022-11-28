using Microsoft.EntityFrameworkCore;
using QuoteRepo.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace QuoteRepo.Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.CountAsync(expression);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasEntity = await _repository.GetByIdAsync(id);
            if (hasEntity == null)
                throw new Exception($"{typeof(T).Name}({id}) not found.");//düzelt NotFoundException olarak
            return hasEntity;
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
