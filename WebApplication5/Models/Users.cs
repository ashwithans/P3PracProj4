using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Marks { get; set; }
    }
}
