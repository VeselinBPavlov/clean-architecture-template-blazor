﻿namespace Template.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        string? CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string? LastModifiedBy { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}