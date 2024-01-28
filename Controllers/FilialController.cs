using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class FilialController : Controller
{
    [HttpPost]
    public ActionResult<MFilial> PostFilial([FromForm] string nome, [FromForm] int codEndereco, 
    [FromForm] int quantidadeQuartoSolteiro, [FromForm] int quantidadeQuartoCasal, 
    [FromForm] int quantidadeQuartoFamilia, [FromForm] int quantidadeQuartoPresidencial, [FromForm] int quantidadeEstrelas)
    {
        using (var _context = new HotelProjetoContext())
        {
            MEndereco? endereco = _context.MEndereco.Find(codEndereco);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado!");
            }

            MFilial filial = new MFilial(nome, endereco, quantidadeQuartoSolteiro, quantidadeQuartoCasal, quantidadeQuartoFamilia,
            quantidadeQuartoPresidencial, quantidadeEstrelas);
            _context.MFilial.Add(filial);
            _context.SaveChanges();

            return Ok(filial);
        }
    }

    [HttpGet]
    public List<MFilial> GetFiliais()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFilial.Include(f => f.Endereco).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetFilialCod([FromQuery] int codFilial)
    {
        using (var _context = new HotelProjetoContext())
        {
            var filial = _context.MFilial.Include(f => f.Endereco)
            .FirstOrDefault(f => f.CodFilial == codFilial);
            if (filial == null)
            {
                return NotFound("Filial não encontrada.");
            }
            return new ObjectResult(filial);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MFilial> PutFilial([FromForm] int codFilial, [FromForm] string nome, [FromForm] int codEndereco, 
    [FromForm] int quantidadeQuartoSolteiro, [FromForm] int quantidadeQuartoCasal, 
    [FromForm] int quantidadeQuartoFamilia, [FromForm] int quantidadeQuartoPresidencial, [FromForm] int quantidadeEstrelas)
    {
        using (var _context = new HotelProjetoContext())
        {
            MEndereco? endereco = _context.MEndereco.Find(codEndereco);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado!");
            }

            var filial = _context.MFilial.FirstOrDefault(f => f.CodFilial == codFilial);
            if (filial == null)
            {
                return NotFound("Filial não encontrada!");
            }
            try
            {
                filial.Nome = nome;
                filial.Endereco = endereco;
                filial.QuantidadeQuartoSolteiro = quantidadeQuartoSolteiro;
                filial.QuantidadeQuartoCasal = quantidadeQuartoCasal;
                filial.QuantidadeQuartoFamilia = quantidadeQuartoFamilia;
                filial.QuantidadeQuartoPresidencial = quantidadeQuartoPresidencial;
                filial.QuantidadeQuartoPresidencial = quantidadeQuartoPresidencial;

                _context.SaveChanges();

                return Ok(filial);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização da filial: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public IActionResult DeleteFilial([FromForm] int codFilial)
    {
        using (var _context = new HotelProjetoContext())
        {
            var filial = _context.MFilial.FirstOrDefault(f => f.CodFilial == codFilial);
            if (filial == null)
            {
                return NotFound("Filial não encontrada!");
            }
            _context.MFilial.Remove(filial);
            _context.SaveChanges();

            return Ok("Filial excluída!");
        }
    }
}