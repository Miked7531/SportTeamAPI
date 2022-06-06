using SportTeam.API.Models.Player;

namespace SportTeam.API.Models.Team
{
    public class GetTeamDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<GetPlayerDto> Players { get; set; }
    }
}
