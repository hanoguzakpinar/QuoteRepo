﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRepo.Shared.Results
{
    public class Result : IResult
    {
        public Result()
        {
            Errors = new List<ValidationResult>();
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
        public Result(ResultStatus resultStatus, int errorCount, List<ValidationResult> errors)
        {
            ResultStatus = resultStatus;
            ErrorCount = errorCount;
            Errors = errors;
        }
        public Result(int errorCount, List<ValidationResult> errors)
        {
            ErrorCount = errorCount;
            Errors = errors;
        }
        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public int ErrorCount { get; set; }
        public List<ValidationResult> Errors { get; set; }
    }
}
