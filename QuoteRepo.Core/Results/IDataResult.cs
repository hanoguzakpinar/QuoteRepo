namespace QuoteRepo.Core.Results
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
