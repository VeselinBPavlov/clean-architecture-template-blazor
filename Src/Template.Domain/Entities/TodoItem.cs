﻿using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class TodoItem : BaseEntity<int>
    {
        public int ListId { get; set; }

        public string Title { get; set; } = default!;

        public string? Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }

        public TodoList List { get; set; } = new();
    }
}
