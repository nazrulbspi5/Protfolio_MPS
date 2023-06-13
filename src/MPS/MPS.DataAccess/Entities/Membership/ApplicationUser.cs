using Microsoft.AspNetCore.Identity;

namespace MPS.DataAccess.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? Name { get; set; }
    }
}