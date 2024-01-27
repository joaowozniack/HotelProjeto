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
            var item = _context.MFuncionario.FirstOrDefault(q => q.codFuncionario == numeroQuarto);
            if (item == null)
            {
                return NotFound("Quarto não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("id")]
    public void PutFuncionario([FromQuery] int id, [FromBody] MFuncionario funcionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFuncionario.FirstOrDefault(t => t.codFuncionario == id);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(funcionario);
            _context.SaveChanges();
        }
    }

    [HttpDelete("id")]
    public void DeleteFuncionario([FromQuery] int id)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MCliente.FirstOrDefault(c => c.codCliente == id);
            if (item == null)
            {
                return;
            }
            _context.MCliente.Remove(item);
            _context.SaveChanges();
        }
    }
}