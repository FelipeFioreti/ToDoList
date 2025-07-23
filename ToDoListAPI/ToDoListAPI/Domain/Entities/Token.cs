using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Domain.Entities.Base;

namespace ToDoListAPI.Domain.Entities
{
    public class Token : BaseEntity
    {
        [ForeignKey("User"), Required(ErrorMessage = "Por favor insira o Id do Usuario")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required(ErrorMessage = "Por favor insira o valor do Token")]
        public string Value { get; set; } = string.Empty;

        public Token(int id, string value)
        {
            UserId = id;
            Value = value;
        }
    }
}
