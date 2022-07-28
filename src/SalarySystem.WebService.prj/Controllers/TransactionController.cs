using Microsoft.AspNetCore.Mvc;

namespace SalarySystem.WebService.Controllers;

/// <summary>Controller containing transaction api.</summary>
[ApiController]
[Route("[controller]/[action]")]
public class TransactionController : Controller
{
    /// <summary>Get base creating transaction view </summary>
    /// <returns>Base creating transaction view</returns>
    [HttpGet]
    public IActionResult AddingEmployee()
    {
        return View();
    }
}
