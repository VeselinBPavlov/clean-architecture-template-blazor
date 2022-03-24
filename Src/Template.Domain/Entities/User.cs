using Microsoft.AspNetCore.Identity;

namespace Template.Domain.Entities
{
    public class User : IdentityUser<string>, IHasDomainEvent, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
