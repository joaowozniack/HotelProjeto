using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class FormaPagamentoController : Controller
{
    [HttpGet]
    public List<MFormaPagamento> GetFormaPagamentos()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFormaPagamento.ToList();
        }
    }
}