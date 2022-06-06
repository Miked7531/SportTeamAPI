using System.ComponentModel.DataAnnotations.Schema;

namespace SportTeam.API.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey(nameof(TeamId))]
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}