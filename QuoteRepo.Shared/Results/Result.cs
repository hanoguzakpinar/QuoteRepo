using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRepo.Shared.Results
{
    public class Result : IResult
    {
        public string? Message { get; }

        public Result(string? message)
        {
            Message = message;
        }
    }
}
