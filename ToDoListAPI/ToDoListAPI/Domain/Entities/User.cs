using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Domain.Entities.Base;

namespace ToDoListAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres."), Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; } = string.Empty;
        [StringLength(155, ErrorMessage = "O Email deve ter no máximo 155 caracteres.") ,Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; } = string.Empty;
        [PasswordPropertyText ,Required(ErrorMessage = "A sennha é obrigatória")]
        public string Password { get; set; } = string.Empty;

        public void Update(string name, string email, string password)
        {
            base.Update();
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        }
    }
}
