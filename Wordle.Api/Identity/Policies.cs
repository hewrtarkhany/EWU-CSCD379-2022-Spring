using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity
{
    public static class Policies
    {

        // Add policy that checks for the admin flag and a random claim which is a random number between 0 and 1.
        // This determines if you will be chosen by the Claw.
        public const string RandomAdmin = "RandomAdmin";
        public static void RandomAdminPolicy(AuthorizationPolicyBuilder policy)
        {
            policy.RequireRole(Roles.Admin);
            policy.RequireAssertion(context =>
            {
                var random = context.User.Claims.FirstOrDefault(f => f.Type == Claims.Random);
                if (random is not null)
                {
                    if (double.Parse(random.Value) > .5) return true;
                }
                return false;
            });
        }
    }
}
