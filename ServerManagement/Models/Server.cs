using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public Server()
        {
            Random random = new Random();
            int randomNubert = random.Next(0, 2);

            IsOnline = (randomNubert == 0 ? false : true );
        }

        public int ServerId { get; set; }

        public bool IsOnline { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? City { get; set; }
    }
}
