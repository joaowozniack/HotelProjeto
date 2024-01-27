using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class CargoController : Controller
{
    [HttpGet]
    public List<MCargo> GetCargos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MCargo.ToList();
        }
    }
}