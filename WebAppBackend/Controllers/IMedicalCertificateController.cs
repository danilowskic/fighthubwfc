using Microsoft.AspNetCore.Mvc;
using WebAppBackend.DTOs;

namespace WebAppBackend.Controllers;

public interface IMedicalCertificateController
{
    Task<IActionResult> CreateMedicalCertificate([FromBody] MedicalCertificateDTO medicalCertificateDto);
}