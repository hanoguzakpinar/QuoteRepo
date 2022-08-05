using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRepo.Shared.Results
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string? Message { get; }
        public int ErrorCount { get; set; }
        public List<ValidationResult> Errors { get; set; }
    }
}
