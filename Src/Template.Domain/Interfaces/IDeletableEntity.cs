namespace Template.Domain.Interfaces
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }

        string? DeletedBy { get; set; }
    }
}
