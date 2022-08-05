using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRepo.Shared.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult()
        {
            Errors = new List<ValidationResult>();
        }
        public DataResult(T data)
        {
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, int errorCount, List<ValidationResult> errors, T data)
        {
            ResultStatus = resultStatus;
            ErrorCount = errorCount;
            Errors = errors;
            Data = data;
        }
        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public int ErrorCount { get; set; }
        public List<ValidationResult> Errors { get; set; }
        public T Data { get; }
    }
}
