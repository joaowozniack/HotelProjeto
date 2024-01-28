using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class QuartoController : Controller
{
    [HttpPost]
    public void PostQuarto([FromBody] MQuarto quarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MQuarto.Add(quarto);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MQuarto> GetQuartos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MQuarto.ToList();
        }
    }

    [HttpGet("numero")]
    public IActionResult GetQuartoNumero([FromQuery] int numeroQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MQuarto.FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (item == null)
            {
                return NotFound("Quarto não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("numero")]
    public void PutQuarto([FromQuery] int numeroQuarto, [FromBody] MQuarto quarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MQuarto.FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(quarto);
            _context.SaveChanges();
        }
    }

    [HttpDelete("numero")]
    public void DeleteQuarto([FromQuery] int numeroQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MQuarto.FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (item == null)
            {
                return;
            }
            _context.MQuarto.Remove(item);
            _context.SaveChanges();
        }
    }
}