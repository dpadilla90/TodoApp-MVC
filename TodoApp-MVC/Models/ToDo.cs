using System;

namespace TodoApp.Models
{
    public class ToDo
    {
        // Unique identifier for the ToDo item
        public int Id { get; set; }

        // The title or name of the ToDo item
        public string Title { get; set; }

        // A description or details about the ToDo item
        public string Description { get; set; }

        // The date when the ToDo item was completed (can be null if not completed yet)
        public DateTime? CompletionDate { get; set; }

        // A flag indicating whether the ToDo item is completed (true) or not (false)
        public bool IsCompleted { get; set; }
    }
}
