using FluentValidation.Results;

namespace QuoteRepo.Shared.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }

        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, List<ValidationFailure> errors)
        {
            ResultStatus = resultStatus;
            Errors = errors;
        }

        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public List<ValidationFailure> Errors { get; }
        public T Data { get; }
    }
}
