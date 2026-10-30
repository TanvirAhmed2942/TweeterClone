using Microsoft.AspNetCore.Mvc.Filters;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Api.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UserInfoValidatorAttribute : ActionFilterAttribute
    {
        public CreateUserDto All { get; }

        public UserInfoValidatorAttribute(CreateUserDto all)
        {
            All = all;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrWhiteSpace(All.Email))
            {
                Console.WriteLine("Wait Email is not sent");
            }
        }
    }
}
