using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class PagamentoController : Controller
{
    [HttpPost]
    public ActionResult<MPagamento> PostPagamento([FromForm] int numeroConta, [FromForm] int codForma)
    {
        using (var _context = new HotelProjetoContext())
        {
            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada! ");
            }
            MFormaPagamento? forma = _context.MFormaPagamento.Find(codForma);
            if (forma == null)
            {
                return NotFound("Forma de pagamento não encontrada!");
            }

            MPagamento pagamento = new MPagamento(forma, conta);
            _context.MPagamento.Add(pagamento);
            _context.SaveChanges();

            return Ok(pagamento);
        }
    }

    [HttpGet]
    public List<MPagamento> GetPagamentos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MPagamento.Include(p => p.Conta).Include(p => p.Forma).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetPagamentoCod([FromQuery] int codPagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            var pagamento = _context.MPagamento.Include(p => p.Conta).Include(p => p.Forma)
            .FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (pagamento == null)
            {
                return NotFound("Pagamento não encontrado.");
            }
            return new ObjectResult(pagamento);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MPagamento> PutPagamento([FromForm] int codPagamento, [FromForm] int numeroConta,
    [FromForm] int codForma)
    {
        using (var _context = new HotelProjetoContext())
        {
            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada! ");
            }
            MFormaPagamento? forma = _context.MFormaPagamento.Find(codForma);
            if (forma == null)
            {
                return NotFound("Forma de pagamento não encontrada!");
            }

            var pagamento = _context.MPagamento.FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (pagamento == null)
            {
                return NotFound("Pagamento não encontrado!");
            }
            try
            {
                pagamento.Conta = conta;
                pagamento.Forma = forma;
            
                _context.SaveChanges();

                return Ok(pagamento);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização do pagamento: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public ActionResult DeletePagamento([FromForm] int codPagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            
            var pagamento = _context.MPagamento.FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (pagamento == null)
            {
                return NotFound("Pagamento não encontrado!");
            }
            _context.MPagamento.Remove(pagamento);
            _context.SaveChanges();

            return Ok("Pagamento excluído!");
        }
    }
}