using System.ComponentModel.DataAnnotations;

namespace SportTeam.API.Models.Team
{
    public abstract class BaseTeamDto
    {
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
