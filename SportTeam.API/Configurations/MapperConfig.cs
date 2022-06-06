using AutoMapper;
using SportTeam.API.Data;
using SportTeam.API.Models.Country;
using SportTeam.API.Models.Player;
using SportTeam.API.Models.Team;

namespace SportTeam.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //team mappings
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, GetTeamDto>().ReverseMap();
            CreateMap<Team, GetTeamDetailsDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();

            //player mappings
            CreateMap<Player, GetPlayerDto>().ReverseMap();
        }
    }
}
