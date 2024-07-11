using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
