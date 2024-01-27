using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class EnderecoController : Controller
{
    [HttpGet]
    public List<MEndereco> GetEnderecos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MEndereco.ToList();
        }
    }
}