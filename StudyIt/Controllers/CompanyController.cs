using Microsoft.AspNetCore.Mvc;
using StudyIt.MongoDB.Models;
using StudyIt.MongoDB.Services;

namespace StudyIt.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CompanyController : Controller
{
    private readonly CompanyService _companyService;
    private  Firebase firebase;
    

    public CompanyController(CompanyService companyService) {
        _companyService = companyService;
         firebase = Firebase.GetInstance();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> PostCompany(Company newCompany)
    {
        await _companyService.CreateCompany(newCompany);
        
        Console.WriteLine(newCompany);

        return CreatedAtAction(nameof(GetCompany), new { email = newCompany.email }, newCompany);
    }

    [HttpGet]
    [Route("getCompanyByEmail")]
    public async Task<ActionResult<Company>> GetCompany(string email)
    {
         if (Request.Headers.TryGetValue("token", out var value))
        {
            string  token = value;
            if (firebase.varify(token).Result)
            {
                var company = await _companyService.GetCompanyByEmail(email);
        
                Console.WriteLine(company.description);

                 if (company == null)
                 {
                     return NotFound();
                 }

                 return company;
            }
        }
            return Unauthorized();
        
    }

     [HttpGet]
    [Route("getCompanyById")]
    public async Task<ActionResult<Company>> GetCompanyById(string _id)
    {
         if (Request.Headers.TryGetValue("token", out var value))
        {
            string  token = value;
            if (firebase.varify(token).Result)
            {
                var company = await _companyService.GetCompanyById(_id);
        
                Console.WriteLine(company.description);

                 if (company == null)
                 {
                     return NotFound();
                 }

                 return company;
            }
        }
            return Unauthorized();
        
    }
    //updating company
    [HttpPut]
    [Route("updateCompany")]
    public async Task<ActionResult<Company>> updateCompany(Company company)
    {
         if (Request.Headers.TryGetValue("token", out var value))
        {
            string  token = value;
            if (firebase.varify(token).Result)
            {
                var result = await _companyService.updateCompany(company);
                Console.WriteLine("as MatchedCount: "+ result.MatchedCount);
                 if (result.MatchedCount == 0)
                 {
                     return NotFound();
                 }
                 return Ok();
            }
        }
            return Unauthorized();
        
    }
}