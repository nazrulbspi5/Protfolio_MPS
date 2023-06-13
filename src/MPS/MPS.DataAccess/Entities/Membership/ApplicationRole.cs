using Microsoft.AspNetCore.Identity;

namespace MPS.DataAccess.Entities.Membership
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        { 

        }
    }
}