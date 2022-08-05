using FluentValidation.Results;

namespace QuoteRepo.Shared.Results
{
    public class Result : IResult
    {
        public Result()
        {
            Errors = new List<ValidationFailure>();
        }
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, List<ValidationFailure> errors)
        {
            ResultStatus = resultStatus;
            Errors = errors;
        }
        public Result(List<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public Result(string message)
        {
            Message = message;
        }

        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public List<ValidationFailure> Errors { get; set; }
    }
}
