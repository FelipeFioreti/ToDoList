using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Domain.Entities.Base;

namespace ToDoListAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(100, ErrorMessage = "O Nome deve ter no m�ximo 100 caracteres."), Required(ErrorMessage = "O nome � obrigat�rio")]
        public string Name { get; set; } = string.Empty;
        [StringLength(155, ErrorMessage = "O Email deve ter no m�ximo 155 caracteres.") ,Required(ErrorMessage = "O email � obrigat�rio")]
        public string Email { get; set; } = string.Empty;
        [PasswordPropertyText ,Required(ErrorMessage = "A sennha � obrigat�ria")]
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
