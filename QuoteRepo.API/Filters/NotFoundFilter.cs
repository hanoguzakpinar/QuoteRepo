using Microsoft.AspNetCore.Mvc.Filters;

namespace QuoteRepo.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
            }

            bool anyEntity;
            int id;

            if (idValue?.GetType() == typeof(int))
            {
                id = (int)idValue;
                anyEntity = await _service.AnyAsync(x => x.Id == id);
            }
            else
            {
                id = (int)idValue?.GetType()
                                  .GetProperty("Id")
                                  .GetValue(idValue, null);
                anyEntity = await _service.AnyAsync(x => x.Id == id);
            }

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(Result<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found."));
        }
    }
}
