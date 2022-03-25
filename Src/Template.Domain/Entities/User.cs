using Microsoft.AspNetCore.Identity;

namespace Template.Domain.Entities
{
    public class User : IdentityUser, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }
    }
}
