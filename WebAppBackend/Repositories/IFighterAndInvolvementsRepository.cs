using WebAppBackend.DTOs;
using WebAppBackend.Enums;
using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public interface IFighterAndInvolvementsRepository
{
    Task<IEnumerable<FighterDTO>> GetAllFightersAsync();
    Task<IEnumerable<FighterInvolvementDTO>> GetPendingFighterInvolvementsNumberIDByFighterId(int fighterId);
    Task<EventDTO> GetEventById(int id);
    Task UpdateFighterInvolvementStatus(int id, StatusType statusType);
    Task<IEnumerable<Fighter>> GetFightersByWeightScale(WeightScale scale);
}