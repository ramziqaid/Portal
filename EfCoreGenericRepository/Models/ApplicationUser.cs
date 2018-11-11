using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EfCoreGenericRepository.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser2 : IdentityUser
    {
        public long EmployeeID { get; set; }
    }
}
