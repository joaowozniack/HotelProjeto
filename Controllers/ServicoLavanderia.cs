using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ServicoLavanderiaController : Controller
{
    [HttpPost]
    public void PostServicoLavanderia([FromBody] MServicoLavanderia servicoLavanderia)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MServicoLavanderia.Add(servicoLavanderia);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MServicoLavanderia> GetServicoLavanderias()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MServicoLavanderia.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetServicoLavanderiaCod([FromQuery] int codServico)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MServicoLavanderia.FirstOrDefault(p => p.codServico == codServico);
            if (item == null)
            {
                return NotFound("Filial não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutServicoLavanderia([FromQuery] int codServico, [FromBody] MServicoLavanderia servicoLavanderia)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MServicoLavanderia.FirstOrDefault(p => p.codServico == codServico);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(servicoLavanderia);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteServicoLavanderia([FromQuery] int codServico)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MServicoLavanderia.FirstOrDefault(p => p.codServico == codServico);
            if (item == null)
            {
                return;
            }
            _context.MServicoLavanderia.Remove(item);
            _context.SaveChanges();
        }
    }
}