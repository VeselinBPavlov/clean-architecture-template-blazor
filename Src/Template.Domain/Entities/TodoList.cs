namespace Template.Domain.Entities
{
    public class TodoList : BaseEntity<int>
    {
        public TodoList()
        {
           this.Items = new List<TodoItem>();
        }

        public string Title { get; set; } = default!;

        public string Colour { get; set; } = default!;

        public IList<TodoItem> Items { get; set; }
    }
}
