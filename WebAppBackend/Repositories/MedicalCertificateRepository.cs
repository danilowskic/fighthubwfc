using Microsoft.EntityFrameworkCore;
using WebAppBackend.Configurations;
using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public class MedicalCertificateRepository : IMedicalCertificateRepository
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<MedicalCertificate> _dbSet;
        
    public MedicalCertificateRepository(FightHubDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<MedicalCertificate>();
    }
    
    public async Task AddAsync(MedicalCertificate medicalCertificate)
    {
        await _dbSet.AddAsync(medicalCertificate);
        await _dbContext.SaveChangesAsync();
    }
}