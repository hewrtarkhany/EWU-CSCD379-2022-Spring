using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data
{
    public class AppUser: IdentityUser
    {
        public string? DateOfBirth { get; set;}
        public bool? isMasterOfTheUniverse { get; set;}
        
    }
}
