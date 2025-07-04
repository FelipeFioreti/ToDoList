using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int UserId { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("password")]
        public string Password { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
