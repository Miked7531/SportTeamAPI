using System.ComponentModel.DataAnnotations.Schema;

namespace SportTeam.API.Data
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public virtual IList<Player> Players { get; set; }
    }
}