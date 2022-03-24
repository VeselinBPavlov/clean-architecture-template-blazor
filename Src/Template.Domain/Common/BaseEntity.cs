namespace Template.Domain.Common
{
    public abstract class BaseEntity<TKey> : IAuditableEntity
    {
        public TKey Id { get; set; } = default!;

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}