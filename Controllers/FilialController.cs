using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class FilialController : Controller
{
    [HttpPost]
    public void PostFilial([FromBody] MFilial filial)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MFilial.Add(filial);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MFilial> GetFiliais()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFilial.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetFilial([FromQuery] int codFilial)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFilial.FirstOrDefault(f => f.CodFilial == codFilial);
            if (item == null)
            {
                return NotFound("Filial não encontrada.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutFilial([FromQuery] int codFilial, [FromBody] MFilial filial)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFilial.FirstOrDefault(f => f.CodFilial == codFilial);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(filial);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteFilial([FromQuery] int codFilial)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFilial.FirstOrDefault(f => f.CodFilial == codFilial);
            if (item == null)
            {
                return;
            }
            _context.MFilial.Remove(item);
            _context.SaveChanges();
        }
    }
}