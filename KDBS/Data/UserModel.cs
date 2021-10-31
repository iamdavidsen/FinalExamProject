using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KDBS.Data
{
    public class UserModel : IdentityUser
    {
        public RecruiterModel? Recruiter { get; set; }
    }
}
