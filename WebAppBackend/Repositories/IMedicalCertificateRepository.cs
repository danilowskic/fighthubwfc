using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public interface IMedicalCertificateRepository
{
    Task AddAsync(MedicalCertificate medicalCertificate);
}