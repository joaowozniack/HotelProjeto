using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class PagamentoController : Controller
{
    [HttpPost]
    public void PostPagamento([FromBody] MPagamento pagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MPagamento.Add(pagamento);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MPagamento> GetPagamentos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MPagamento.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetPagamentoCod([FromQuery] int codPagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MPagamento.FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (item == null)
            {
                return NotFound("Pagamento não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutPagamento([FromQuery] int codPagamento, [FromBody] MPagamento pagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MPagamento.FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(pagamento);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeletePagamento([FromQuery] int codPagamento)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MPagamento.FirstOrDefault(p => p.CodPagamento == codPagamento);
            if (item == null)
            {
                return;
            }
            _context.MPagamento.Remove(item);
            _context.SaveChanges();
        }
    }
}