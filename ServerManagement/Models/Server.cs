using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public int ServerId { get; set; }

        public bool IsOnline { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? City { get; set; }
    }
}
