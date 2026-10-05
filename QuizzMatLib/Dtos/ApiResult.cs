using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzMatLib.Dtos
{
    public record ApiResult(bool IsSuccess, string? Error)
    {
        public static ApiResult Success() => new(true, null);
        public static ApiResult Fail(string ErrorMessage) => new(false, ErrorMessage);
    }

    public record ApiResult<TData>(bool IsSuccess, TData Data, string? Error)
    {
        public static ApiResult<TData> Success(TData data) => new(true, data, null);
        public static ApiResult<TData> Fail(string ErrorMessage) => new(false, default!, ErrorMessage);
    }
}
