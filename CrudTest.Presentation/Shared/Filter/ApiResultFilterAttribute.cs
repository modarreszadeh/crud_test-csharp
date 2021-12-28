using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudTest.Presentation.Shared.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shared.Filter
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                SerializableError serialError = new SerializableError(context.ModelState);
                var errors = serialError.SelectMany(p => (string[])p.Value).Distinct();
                var apiResult = new ApiResult(ApiResultStatusCode.BadRequest, errors.ToList());
                context.Result = new JsonResult(apiResult);
            }

            base.OnResultExecuting(context);
        }
    }
}