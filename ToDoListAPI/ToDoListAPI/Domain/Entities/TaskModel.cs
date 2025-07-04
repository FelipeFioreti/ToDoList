using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Domain.Entities
{
    [Table("tasks")]
    public class TaskModel
    {
        [Column("id")]
        public int TaskId { get; set; }
        [Column("title")]
        public string Title { get; set; } = string.Empty;
        [Column("content")]
        public string Content { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Column("status_id")]
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; } = null!;
    }
}
