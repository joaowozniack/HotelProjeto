using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class QuartoController : Controller
{
    [HttpPost]
    public ActionResult<MQuarto> PostQuarto([FromForm] int codTipoQuarto, [FromForm] double valorQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            MTipoQuarto? tipoQuarto = _context.MTipoQuarto.Find(codTipoQuarto);

            if (tipoQuarto == null)
            {
                return NotFound("Tipo de Quarto não encontrado!");
            }

            MQuarto quarto = new MQuarto(tipoQuarto, valorQuarto);
            _context.MQuarto.Add(quarto);
            _context.SaveChanges();

            return Ok(quarto);
        }
    }

    [HttpGet]
    public List<MQuarto> GetQuartos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MQuarto.Include(q => q.TipoQuarto).ToList();
        }
    }

    [HttpGet("numero")]
    public IActionResult GetQuartoNumero([FromQuery] int numeroQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            var quarto = _context.MQuarto.Include(q => q.TipoQuarto)
            .FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (quarto == null)
            {
                return NotFound("Quarto não encontrado.");
            }
            return new ObjectResult(quarto);
        }
    }

    [HttpPut("numero")]
    public ActionResult<MQuarto> PutQuarto([FromForm] int numeroQuarto, [FromForm] int codTipoQuarto, 
    [FromForm] double valorQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            MTipoQuarto? tipoQuarto = _context.MTipoQuarto.Find(codTipoQuarto);

            if (tipoQuarto == null)
            {
                return NotFound("Tipo de Quarto não encontrado!");
            }

            var quarto = _context.MQuarto.FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (quarto == null)
            {
                return NotFound("Quarto não encontrado!");
            }
            try
            {
                quarto.TipoQuarto = tipoQuarto;
                quarto.ValorQuarto = valorQuarto;

                _context.SaveChanges();

                return Ok(quarto);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização do quarto: {ex.Message}");
            }
        }
    }

    [HttpDelete("numero")]
    public IActionResult DeleteQuarto([FromForm] int numeroQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            var quarto = _context.MQuarto.FirstOrDefault(q => q.NumeroQuarto == numeroQuarto);
            if (quarto == null)
            {
                return NotFound("Quarto não encontrado!");
            }
            _context.MQuarto.Remove(quarto);
            _context.SaveChanges();

            return Ok("Quarto excluído!");
        }
    }
}