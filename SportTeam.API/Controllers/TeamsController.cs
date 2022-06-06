using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportTeam.API.Data;
using SportTeam.API.Models.Country;
using SportTeam.API.Models.Team;

namespace SportTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly SportTeamDbContext _context;
        private readonly IMapper _mapper;

        public TeamsController(SportTeamDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTeamDto>>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            var records = _mapper.Map<List<GetTeamDto>>(teams);
            return Ok(records);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeamDetailsDto>> GetTeam(int id)
        {
            var team = await _context.Teams.Include(q => q.Players).FirstOrDefaultAsync(q => q.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            var teamDto = _mapper.Map<GetTeamDetailsDto>(team);

            return Ok(teamDto);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, UpdateTeamDto updateTeamDto)
        {
            if (id != updateTeamDto.Id)
            {
                return BadRequest("Invalid Id");
            }

            //_context.Entry(team).State = EntityState.Modified;

            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            _mapper.Map(updateTeamDto, team);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(CreateTeamDto createTeamDto)
        {
            var teamOld = new Team
            {
                Name = createTeamDto.Name,
                Location = createTeamDto.Location
            };

            var team = _mapper.Map<Team>(createTeamDto);

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
