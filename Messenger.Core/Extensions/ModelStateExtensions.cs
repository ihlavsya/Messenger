using Messenger.Core.ResponseModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messenger.Core.Extensions
{
    public static class ModelStateExtensions
    {
        public static ErrorMessage ToErrorMessage(this ModelStateDictionary modelState)
        {
            var message = String.Join(", ", modelState.Values.SelectMany(m => m.Errors)
                .Select(e => e.ErrorMessage));
            return new ErrorMessage
            {
                Code = 400,
                Message = message
            };
        }
    }
}
