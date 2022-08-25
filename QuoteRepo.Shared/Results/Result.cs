namespace QuoteRepo.Shared.Results
{
    public class Result : IResult
    {
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

        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public List<ValidationFailure> Errors { get; }
    }
}
