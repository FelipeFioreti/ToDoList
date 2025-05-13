using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Entities.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
    }
}
