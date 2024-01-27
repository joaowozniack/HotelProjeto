using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class FuncionarioController : Controller
{
    [HttpPost]
    public void PostFuncionario([FromBody] MFuncionario funcionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MFuncionario.Add(funcionario);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MFuncionario> GetFuncionarios()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFuncionario.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetFuncionarioCod([FromQuery] int codFuncionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFuncionario.FirstOrDefault(f => f.codFuncionario == codFuncionario);
            if (item == null)
            {
                return NotFound("Funcionário não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutFuncionario([FromQuery] int codFuncionario, [FromBody] MFuncionario funcionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFuncionario.FirstOrDefault(t => t.codFuncionario == codFuncionario);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(funcionario);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteFuncionario([FromQuery] int codFuncionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MFuncionario.FirstOrDefault(f => f.codFuncionario == codFuncionario);
            if (item == null)
            {
                return;
            }
            _context.MFuncionario.Remove(item);
            _context.SaveChanges();
        }
    }
}