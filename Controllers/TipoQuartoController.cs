using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class TipoQuartoController : Controller
{
    [HttpGet]
    public List<MTipoQuarto> GetTiposQuartos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MTipoQuarto.ToList();
        }
    }
}