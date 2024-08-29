using Microsoft.EntityFrameworkCore;
using WebAppBackend.Configurations;
using WebAppBackend.DTOs;
using WebAppBackend.Enums;
using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public class FightersAndInvolvementsRepository : IFighterAndInvolvementsRepository
{
    protected readonly DbContext _dbContext;
        
    public FightersAndInvolvementsRepository(FightHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<FighterDTO>> GetAllFightersAsync()
    {
        return await _dbContext.Set<Fighter>()
            .Include(f => f.Names)
            .Select(f => new FighterDTO
            {
                Id = f.Id,
                Names = f.Names.Select(fn => fn.name).ToList(),
                Surname = f.Surname,
                Gender = f.Gender.ToString(),
                Height = f.Height,
                Weight = f.Weight,
                WeightScale = f.WeightScale.ToString()
            })
            .ToListAsync();
    }
    
    public async Task<IEnumerable<FighterInvolvementDTO>> GetPendingFighterInvolvementsNumberIDByFighterId(int fighterId)
    {
        return await _dbContext.Set<FighterInvolvement>()
            .Where(fi => fi.FighterId == fighterId && fi.Status == StatusType.PENDING)
            .Select(fi => new FighterInvolvementDTO
            {
                Id = fi.Id,
                NumberID = fi.NumberID,
                RegistrationDateTime = fi.RegistrationDate,
                EventId = fi.EventId
            })
            .ToListAsync();
    }

    public async Task<EventDTO> GetEventById(int id)
    {
        var eventFound = await _dbContext.Set<Event>()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        var eventDTO = new EventDTO
        {
            Name = eventFound.Name,
            Street = eventFound.Localization.Street,
            BuildingNumber = eventFound.Localization.BuildingNumber,
            ApartmentNumber =
                Convert.ToString(eventFound.Localization.ApartmentNumber == null ? "" : eventFound.Localization.ApartmentNumber),
            City = eventFound.Localization.City,
            Zipcode = eventFound.Localization.ZipCode,
            DateTime = eventFound.DateTime.ToString("dd MMMM yyyy, HH:mm")
        };

        return eventDTO;
    }

    public async Task UpdateFighterInvolvementStatus(int id, StatusType statusType)
    {
        var fighterInvolvement = await _dbContext.Set<FighterInvolvement>()
            .FindAsync(id);
        
        if (fighterInvolvement != null)
        {
            fighterInvolvement.Status = statusType;
            _dbContext.Set<FighterInvolvement>().Update(fighterInvolvement);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("FighterInvolvement not found.");
        }
    }
    
    
    public async Task<IEnumerable<Fighter>> GetFightersByWeightScale(WeightScale scale)
    {
        return await _dbContext.Set<Fighter>()
            .Where(f => f.WeightScale == scale)
            .ToListAsync();
    }
}