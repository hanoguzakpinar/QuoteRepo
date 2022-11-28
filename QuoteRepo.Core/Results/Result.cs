using System.Text.Json.Serialization;

namespace QuoteRepo.Core.Results
{
    public class Result<T>
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public static Result<T> Success(int statusCode, T data)
        {
            return new Result<T> { Data = data, StatusCode = statusCode };
        }
        public static Result<T> Success(int statusCode)
        {
            return new Result<T> { StatusCode = statusCode };
        }
        public static Result<T> Fail(int statusCode, List<string> errors)
        {
            return new Result<T> { Errors = errors, StatusCode = statusCode };
        }
        public static Result<T> Fail(int statusCode, string error)
        {
            return new Result<T> { Errors = new List<string> { error }, StatusCode = statusCode };
        }
    }
}
