using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Domain.Entities.Base;

namespace ToDoListAPI.Domain.Entities
{
    public class Status : BaseEntity
    {
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres."), Required(ErrorMessage = "O nome do status é obrigatório.")]
        public string Name { get; set; } = string.Empty;
    

        public void Update(string name)
        {
            base.Update();
            this.Name = name;
        }

    } 
}
