using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API.Enums;

namespace WEB_API.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
