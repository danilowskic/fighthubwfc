using Microsoft.AspNetCore.Mvc;
using WebAppBackend.DTOs;
using WebAppBackend.Enums;
using WebAppBackend.Models;
using WebAppBackend.Repositories;

namespace WebAppBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalCertificateController : ControllerBase, IMedicalCertificateController
{
    private readonly IMedicalCertificateRepository _medicalCertificateRepository;
    private readonly IFighterAndInvolvementsRepository _fighterAndInvolvementsRepository;

    public MedicalCertificateController(IMedicalCertificateRepository medicalCertificateRepository, IFighterAndInvolvementsRepository fighterAndInvolvementsRepository)
    {
        _medicalCertificateRepository = medicalCertificateRepository;
        _fighterAndInvolvementsRepository = fighterAndInvolvementsRepository;
    }
    
    [HttpPost("createMedicalCertificate")]
    public async Task<IActionResult> CreateMedicalCertificate([FromBody] MedicalCertificateDTO medicalCertificateDto)
    {
        ;
        Console.WriteLine("IsAccepted : " + medicalCertificateDto.IsAccepted);
        Console.WriteLine("Description : " + medicalCertificateDto.Description);
        Console.WriteLine("FighterInvolvementId : " + medicalCertificateDto.FighterInvolvementId);
        Console.WriteLine("FighterId : " + medicalCertificateDto.FighterId);
        
        var medicalCertificate = new MedicalCertificate
        {
            NumberId = "OPINIALEKARSKA123",
            IsAccepted = medicalCertificateDto.IsAccepted,
            Description = medicalCertificateDto.Description,
            DateTime = DateTime.Now,
            FighterInvolvementId = medicalCertificateDto.FighterInvolvementId,
            FighterId = medicalCertificateDto.FighterId,
            WorkerFanId = 1
        };
        
        
        await _medicalCertificateRepository.AddAsync(medicalCertificate);

        if (medicalCertificateDto.IsAccepted)
        {
            await _fighterAndInvolvementsRepository
                .UpdateFighterInvolvementStatus(medicalCertificateDto.FighterInvolvementId, StatusType.ACCEPTED);
        }
        else
        {
            await _fighterAndInvolvementsRepository
                .UpdateFighterInvolvementStatus(medicalCertificateDto.FighterInvolvementId, StatusType.REJECTED);
        }

        return Ok("Medical Certificate created successfully.");
    }
}