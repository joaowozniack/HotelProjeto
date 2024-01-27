using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class TipoServicoLavanderia : Controller
{
    [HttpGet]
    public List<MEndereco> GetTipoServicoLavanderias()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MEndereco.ToList();
        }
    }
}