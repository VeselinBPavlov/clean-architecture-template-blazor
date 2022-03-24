namespace Template.Domain.Common
{
    public abstract class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public void Delete(string userId)
        {
            DeletedBy = userId;
            DeletedOn = DateTime.Now;
            IsDeleted = true;
        }
    }
}
