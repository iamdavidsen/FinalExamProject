using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KDBS.Data
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public CompanyModel? Company { get; set; }
    }
}
