using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelProjetoController : Controller
    {
        [HttpPost("cliente")]
        public void PostCliente([FromBody] MCliente cliente)
        {
            using (var _context = new HotelProjetoContext())
            {
                _context.MCliente.Add(cliente);
                _context.SaveChanges();
            }
        }

        [HttpGet("cliente")]
        public List<MCliente> GetClientes()
        {
            using (var _context = new HotelProjetoContext())
            {
                return _context.MCliente.ToList();
            }
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetClienteId(int id)
        {
            using (var _context = new HotelProjetoContext())
            {
                var item = _context.MCliente.FirstOrDefault(c => c.codCliente == id);
                if (item == null)
                {
                    return NotFound("Cliente não encontrado.");
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("cliente/{id}")]
        public void PutCliente(int id, [FromBody] MCliente cliente)
        {
            using (var _context = new HotelProjetoContext())
            {
                var item = _context.MCliente.FirstOrDefault(t => t.codCliente == id);
                if (item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(cliente);
                _context.SaveChanges();
            }
        }

        [HttpDelete("cliente/{id}")]
        public void DeleteCliente(int id)
        {
            using (var _context = new HotelProjetoContext())
            {
                var item = _context.MCliente.FirstOrDefault(t => t.codCliente == id);
                if (item == null)
                {
                    return;
                }
                _context.MCliente.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}