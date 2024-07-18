using Microsoft.AspNetCore.Mvc;
using WebAppBackend.DTOs;
using WebAppBackend.Enums;
using WebAppBackend.Models;

namespace WebAppBackend.Controllers;

public interface IController
{
    Task<ActionResult<IEnumerable<FighterDTO>>> GetAllFighters();
    Task<ActionResult<IEnumerable<FighterInvolvementDTO>>> GetPendingFighterInvolvements(int id);
    Task<ActionResult<EventDTO>> GetEvent(int id);
    Task<ActionResult<IEnumerable<Fighter>>> GetFightersByWeightScale(WeightScale scale);
}