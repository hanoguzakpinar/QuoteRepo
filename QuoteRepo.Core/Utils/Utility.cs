﻿namespace QuoteRepo.Core.Utils
{
    public static class Utility
    {
        public static object ReturnErrors(IResult result)
        {
            return result.Errors is not null ? new { Errors = result.Errors.Select(x => x.ErrorMessage) } : new { ResultStatus = result.ResultStatus.ToString(), result.Message };
        }
    }
}