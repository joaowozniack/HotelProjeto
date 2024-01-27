using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ContaController : Controller
{
    [HttpPost]
    public void PostConta([FromBody] MConta conta)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MConta.Add(conta);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MConta> GetContas()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MConta.ToList();
        }
    }

    [HttpGet("numero")]
    public IActionResult GetContaNumero([FromQuery] int numeroConta)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConta.FirstOrDefault(c => c.numeroConta == numeroConta);
            if (item == null)
            {
                return NotFound("Quarto não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("numero")]
    public void PutConta([FromQuery] int numeroConta, [FromBody] MConta conta)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConta.FirstOrDefault(c => c.numeroConta == numeroConta);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(conta);
            _context.SaveChanges();
        }
    }

    [HttpDelete("numero")]
    public void DeleteConta([FromQuery] int numeroConta)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConta.FirstOrDefault(q => q.numeroConta == numeroConta);
            if (item == null)
            {
                return;
            }
            _context.MConta.Remove(item);
            _context.SaveChanges();
        }
    }
}