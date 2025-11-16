using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.ResultPattern
{
    public class Result
    {
        public bool Rsl { get; set; }
        public string Message { get; set; } = "";
        public object? Data { get; set; }

        public static Result Success(object? data = null, string message = "عملیات با موفقیت انجام شد") =>
            new Result { Rsl = true, Message = message, Data = data };

        public static Result Failure(string message = "عملیات با خطا مواجه شد") =>
            new Result { Rsl = false, Message = message };

        //Baraye FluentValidation
        public static Result ValidationFailure(List<string> errors, string message = "خطا در اعتبارسنجی ورودی‌ها") =>
            new Result { Rsl = false,Message = message, Data = errors.ToList() };
    }
}
