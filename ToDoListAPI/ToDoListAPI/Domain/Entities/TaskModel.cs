using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Domain.Entities.Base;

namespace ToDoListAPI.Domain.Entities
{
    public class TaskModel : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

        public void Update(string title, string content)
        {
            base.Update();
            this.Title = title;
            this.Content = content;
        }
        public void UpdateStatus(int statusId)
        {
            base.Update();
            this.StatusId = statusId;
        }

    }
}
