using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Entities
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int UserId { get; set; }
<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Domain/Entities/User.cs
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("email")]
=======
        public string UserName { get; set; } = string.Empty;
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/Entities/Models/User.cs
        public string Email { get; set; } = string.Empty;
        [Column("password")]
        public string Password { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
