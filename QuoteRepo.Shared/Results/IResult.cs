﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRepo.Shared.Results
{
    public interface IResult
    {
        public string? Message { get; }
    }
}
