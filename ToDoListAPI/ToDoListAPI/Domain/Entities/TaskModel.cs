using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Entities
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; } = string.Empty;
        public string TaskContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        [ForeignKey("USERS")]
        public int UserId { get; set; }
        [ForeignKey("STATUS")]
        public int StatusId { get; set; }
    }
}
