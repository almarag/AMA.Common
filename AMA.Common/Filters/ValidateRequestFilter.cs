namespace AMA.Common.Filters
{
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class ValidateRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var failures = new List<ValidationFailure>();
                string message = string.Empty;

                foreach (var error in context.ModelState)
                {
                    error.Value.Errors
                        .ToList()
                        .ForEach(e =>
                        {
                            failures.Add(new ValidationFailure(error.Key, e.ErrorMessage));
                        });
                }

                context.Result = new ObjectResult(failures) { StatusCode = 400 };
            }
        }
    }
}
