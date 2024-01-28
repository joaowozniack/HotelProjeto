using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class FuncionarioController : Controller
{
    [HttpPost]
    public ActionResult<MFuncionario> PostFuncionario([FromForm] int codCargo, [FromForm] string nome)
    {
        using (var _context = new HotelProjetoContext())
        {
            MCargo? cargo = _context.MCargo.Find(codCargo);

            if (cargo == null)
            {
                return NotFound("Cargo não encontrado!");
            }

            MFuncionario funcionario = new MFuncionario(cargo, nome);
            _context.MFuncionario.Add(funcionario);
            _context.SaveChanges();

            return Ok(funcionario);
        }
    }

    [HttpGet]
    public List<MFuncionario> GetFuncionarios()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFuncionario.Include(f => f.Cargo).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetFuncionarioCod([FromQuery] int codFuncionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var funcionario = _context.MFuncionario.Include(f => f.Cargo)
            .FirstOrDefault(f => f.CodFuncionario == codFuncionario);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }
            return new ObjectResult(funcionario);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MFuncionario> PutFuncionario([FromForm] int codFuncionario, [FromForm] int codCargo, 
    [FromForm] string nome)
    {
        using (var _context = new HotelProjetoContext())
        {
            MCargo? cargo = _context.MCargo.Find(codCargo);

            if (cargo == null)
            {
                return NotFound("Cargo não encontrado!");
            }

            var funcionario = _context.MFuncionario.FirstOrDefault(f => f.CodFuncionario == codFuncionario);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            try
            {
                funcionario.Cargo = cargo;
                funcionario.Nome = nome;

                _context.SaveChanges();

                return Ok(funcionario);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização do funcionario: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public IActionResult DeleteFuncionario([FromForm] int codFuncionario)
    {
        using (var _context = new HotelProjetoContext())
        {
            var funcionario = _context.MFuncionario.FirstOrDefault(f => f.CodFuncionario == codFuncionario);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            _context.MFuncionario.Remove(funcionario);
            _context.SaveChanges();

            return Ok("Funcionário excluído!");
        }
    }
}