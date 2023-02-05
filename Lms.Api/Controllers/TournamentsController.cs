using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Data.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;
using AutoMapper;
using Lms.Core.Dto;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace Lms.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IUoW uow;
        
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        private readonly LmsApiContext _context;

        public TournamentsController(LmsApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPatch("{tournamentId}")]
        public async Task<ActionResult<TournamentDto>> PatchTournament(int tournamentId,
            /*[FromBody]*/JsonPatchDocument<TournamentDto> patchDocument)
        {
            if (patchDocument != null)
            {
                var tournamentDto = CreateTournamentDto();

                patchDocument.ApplyTo(tournamentDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
          if (_context.Tournament == null)
          {
              return NotFound();
          }
            Tournament tournament = new Tournament();
            var tournamentDTO = _mapper.Map<TournamentDto>(tournament);
                return Ok(tournamentDTO);
            //return await _context.Tournament.ToListAsync();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
          if (_context.Tournament == null)
          {
              return NotFound();
          }
            Tournament tournament = new Tournament();
            var tournamentDTO = _mapper.Map<TournamentDto>(tournament);
            return Ok(tournamentDTO);
            //var tournament = await _context.Tournament.FindAsync(id);

            //if (tournament == null)
            //{
            //    return NotFound();
            //}

            //return tournament;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
          if (_context.Tournament == null)
          {
              return Problem("Entity set 'LmsApiContext.Tournament'  is null.");
          }
            _context.Tournament.Add(tournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }
            var tournament = await _context.Tournament.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournament.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return (_context.Tournament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
