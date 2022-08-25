namespace QuoteRepo.Shared.Results
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public List<ValidationFailure> Errors { get; }
    }
}
