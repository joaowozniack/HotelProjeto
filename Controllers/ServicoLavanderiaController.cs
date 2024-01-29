using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ServicoLavanderiaController : Controller
{
    [HttpPost]
    public ActionResult<MServicoLavanderia> PostServicoLavanderia([FromForm] int numeroConta, [FromForm] int codTipoServico)
    {
        using (var _context = new HotelProjetoContext())
        {

            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }

            MTipoServicoLavanderia? tipoServicoLavanderia = _context.MTipoServicoLavanderia.Find(codTipoServico);
            if (tipoServicoLavanderia == null)
            {
                return NotFound("Tipo de serviço de lavanderia não encontrado!");
            }

            MServicoLavanderia servicoLavanderia = new MServicoLavanderia(conta, tipoServicoLavanderia);
            _context.MServicoLavanderia.Add(servicoLavanderia);
            _context.SaveChanges();

            return Ok(servicoLavanderia);
        }
    }

    [HttpGet]
    public List<MServicoLavanderia> GetServicoLavanderias()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MServicoLavanderia.Include(s => s.NumeroConta).Include(s => s.TipoServico).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetServicoLavanderiaCod([FromQuery] int codServico)
    {
        using (var _context = new HotelProjetoContext())
        {
            var servicoLavanderia = _context.MServicoLavanderia.Include(s => s.NumeroConta).Include(s => s.TipoServico)
            .FirstOrDefault(s => s.CodServico == codServico);
            if (servicoLavanderia == null)
            {
                return NotFound("Serviço de lavanderia não encontrado.");
            }
            return new ObjectResult(servicoLavanderia);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MServicoLavanderia> PutServicoLavanderia([FromForm] int codServico, [FromForm] int numeroConta, 
    [FromForm] int codTipoServico)
    {
        using (var _context = new HotelProjetoContext())
        {
            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }

            MTipoServicoLavanderia? tipoServicoLavanderia = _context.MTipoServicoLavanderia.Find(codTipoServico);
            if (tipoServicoLavanderia == null)
            {
                return NotFound("Tipo de serviço de lavanderia não encontrado!");
            }

            var servicoLavanderia = _context.MServicoLavanderia.FirstOrDefault(p => p.CodServico == codServico);
            if (servicoLavanderia == null)
            {
                return NotFound("Serviço de lavanderia não encontrado!");
            }
            try
            {
                servicoLavanderia.NumeroConta = conta;
                servicoLavanderia.TipoServico = tipoServicoLavanderia;

                _context.SaveChanges();

                return Ok(servicoLavanderia);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização do serviço de lavanderia: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public IActionResult DeleteServicoLavanderia([FromQuery] int codServico)
    {
        using (var _context = new HotelProjetoContext())
        {
            var servicoLavanderia = _context.MServicoLavanderia.FirstOrDefault(p => p.CodServico == codServico);
            if (servicoLavanderia == null)
            {
                return NotFound("Serviço de lavanderia não encontrado!");
            }
            _context.MServicoLavanderia.Remove(servicoLavanderia);
            _context.SaveChanges();

            return Ok("Serviço de lavanderia excluído!");
        }
    }
}