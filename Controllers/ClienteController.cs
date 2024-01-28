using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : Controller
{
    [HttpPost]
    public ActionResult<MCliente> PostCliente([FromForm] string nome, [FromForm] string nacionalidade, [FromForm] string email,
    [FromForm] string telefone)
    {
        try
        {
            using (var _context = new HotelProjetoContext())
            {
                MCliente cliente = _context.MCliente.Add(new MCliente( nome, nacionalidade, email, telefone)).Entity;
                _context.SaveChanges();
                return Ok(cliente);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro na criação do cliente: {ex.Message}");
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
            var item = _context.MCliente.FirstOrDefault(c => c.CodCliente == codCliente);
            if (item == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MCliente> PutCliente([FromForm] int codCliente, [FromForm] string nome, 
    [FromForm] string nacionalidade, [FromForm] string email, [FromForm] string telefone)
    {
        using (var _context = new HotelProjetoContext())
        {
            var cliente = _context.MCliente.FirstOrDefault(c => c.CodCliente == codCliente);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            try
            {
                cliente.Nome = nome;
                cliente.Nacionalidade = nacionalidade;
                cliente.Email = email;
                cliente.Telefone = telefone;

                _context.SaveChanges();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização do cliente: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public IActionResult DeleteCliente([FromForm] int codCliente)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MCliente.FirstOrDefault(c => c.CodCliente == codCliente);
            if (item == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            _context.MCliente.Remove(item);
            _context.SaveChanges();
            return Ok("Cliente excluído");
        }
    }
}
