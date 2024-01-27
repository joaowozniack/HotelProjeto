using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : Controller
{
    [HttpPost]
    public void PostCliente([FromBody] MCliente cliente)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MCliente.Add(cliente);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MCliente> GetClientes()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MCliente.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetClienteId([FromQuery] int codCliente)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MCliente.FirstOrDefault(c => c.codCliente == codCliente);
            if (item == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutCliente([FromQuery] int codCliente, [FromBody] MCliente cliente)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MCliente.FirstOrDefault(t => t.codCliente == codCliente);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(cliente);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteCliente([FromQuery] int codCliente)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MCliente.FirstOrDefault(c => c.codCliente == codCliente);
            if (item == null)
            {
                return;
            }
            _context.MCliente.Remove(item);
            _context.SaveChanges();
        }
    }
}
