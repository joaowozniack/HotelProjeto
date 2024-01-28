using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ContaController : Controller
{
    [HttpPost]
    public ActionResult<MConta> PostConta([FromForm] int codCliente, [FromForm] double valorTotal )
    {
        using (var _context = new HotelProjetoContext())
        {
            MCliente? cliente = _context.MCliente.Find(codCliente);
            
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            MConta conta = new MConta(cliente, valorTotal);
            _context.MConta.Add(conta);
            _context.SaveChanges();

            return Ok(conta);
        }
    }

    [HttpGet]
    public List<MConta> GetContas()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MConta.Include(c => c.Cliente).ToList();
        }
    }

    [HttpGet("numero")]
    public IActionResult GetConta([FromQuery] int numeroConta)
    {
        using (var _context = new HotelProjetoContext())
        {
            var conta = _context.MConta.Include(c => c.Cliente)
            .FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }
            return new ObjectResult(conta);
        }
    }

    [HttpPut("numero")]
    public ActionResult<MConta> PutConta([FromForm] int numeroConta, [FromForm] int codCliente, [FromForm] double valorTotal)
    {
        using (var _context = new HotelProjetoContext())
        {
            MCliente? cliente = _context.MCliente.Find(codCliente);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            var conta = _context.MConta.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }

            try
            {
                conta.Cliente = cliente;
                conta.ValorTotal = valorTotal;

                _context.SaveChanges();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização da Conta: {ex.Message}");
            }
        }
    }

    [HttpDelete("numero")]
    public IActionResult DeleteConta([FromForm] int numeroConta)
    {
        using (var _context = new HotelProjetoContext())
        {
            var conta = _context.MConta.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }
            _context.MConta.Remove(conta);
            _context.SaveChanges();

            return Ok("Conta excluída!");
        }
    }
}