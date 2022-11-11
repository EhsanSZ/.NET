using Identity.Models.Dto.Blog;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Identity.Helpers
{
    public class BlogRequirement: IAuthorizationRequirement
    {
    }

    public class IsBlogForUserAuthorizationHandler : AuthorizationHandler<BlogRequirement, BlogDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            BlogRequirement requirement, BlogDto resource)
        {
           if(context.User.Identity?.Name == resource.UserName)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
