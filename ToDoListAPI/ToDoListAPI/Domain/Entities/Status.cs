using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Domain.Entities
{
    [Table("status")]
    public class Status
    {
        [Column("id")]
        public int StatusId { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
