namespace SportTeam.API.Models.Player
{
    public class GetPlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
    }
}
