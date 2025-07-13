using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Domain.Entities
{
    public class Token
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
        public string Value { get; set; } = string.Empty;

        public Token(int id, string value)
        {
            UserId = id;
            Value = value;
        }
    }
}
