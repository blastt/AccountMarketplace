using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }

        public static Application.Common.Models.SignInResult ToApplicationResult(this Microsoft.AspNetCore.Identity.SignInResult result)
        {
            if (result.Succeeded)
            {
                return Application.Common.Models.SignInResult.Success;
            }
            else if (result.IsLockedOut)
            {
                return Application.Common.Models.SignInResult.LockedOut;
            }
            else if (result.IsNotAllowed)
            {
                return Application.Common.Models.SignInResult.NotAllowed;
            }
            else
            {
                return Application.Common.Models.SignInResult.TwoFactorRequired;
            }
        }
    }
}
