using Microsoft.AspNetCore.Mvc;
using WebAppBackend.DTOs;
using WebAppBackend.Enums;
using WebAppBackend.Models;
using WebAppBackend.Repositories;

namespace WebAppBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase, IController
{
    private readonly IFighterAndInvolvementsRepository _fighterAndInvolvementsRepository;

    public Controller(IFighterAndInvolvementsRepository fighterAndInvolvementsRepository)
    {
        _fighterAndInvolvementsRepository = fighterAndInvolvementsRepository;
    }

    [HttpGet("fighters")]
    public async Task<ActionResult<IEnumerable<FighterDTO>>> GetAllFighters()
    {
        var fighters = await _fighterAndInvolvementsRepository.GetAllFightersAsync();

        if (fighters == null || !fighters.Any())
        {
            return NotFound("Brak jakichkolwiek zawodników");
        }
        
        return Ok(fighters);
    }

    [HttpGet("fighter/{id}/involvements")]
    public async Task<ActionResult<IEnumerable<FighterInvolvementDTO>>> GetPendingFighterInvolvements(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID cannot be <1");
        }
        
        var involvements = await _fighterAndInvolvementsRepository.GetPendingFighterInvolvementsNumberIDByFighterId(id);
        if (involvements == null || !involvements.Any())
        {
            return NotFound("Brak zapisów na wydarzenia dla tego zawodnika");
        }
        
        return Ok(involvements);
    }
    
    [HttpGet("event/{id}")]
    public async Task<ActionResult<EventDTO>> GetEvent(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID cannot be <1");
        }
        
        var event1 = await _fighterAndInvolvementsRepository.GetEventById(id);
        if (event1 == null)
        {
            return NotFound("Brak podanego wydarzenia");
        }
        
        return Ok(event1);
    }
    
    [HttpGet("fightersByWeightScale/{scale}")]
    public async Task<ActionResult<IEnumerable<Fighter>>> GetFightersByWeightScale(WeightScale scale)
    {
        var fighters = await _fighterAndInvolvementsRepository.GetFightersByWeightScale(scale);

        return Ok(fighters);
    }
}