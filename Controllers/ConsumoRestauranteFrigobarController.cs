using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ConsumoRestauranteFrigobarController : Controller
{
    [HttpPost]
    public ActionResult<MConsumoRestauranteFrigobar> PostConsRestFrig([FromForm] int numeroConta, [FromForm] string descricao,
    [FromForm] double valor, [FromForm] bool restauranteEntregaQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);
            
            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }

            MConsumoRestauranteFrigobar consumoRestauranteFrigobar = new MConsumoRestauranteFrigobar(conta, descricao, valor,
            restauranteEntregaQuarto);
            _context.MConsumoRestauranteFrigobar.Add(consumoRestauranteFrigobar);
            _context.SaveChanges();

            return Ok(consumoRestauranteFrigobar);
        }
    }

    [HttpGet]
    public List<MConsumoRestauranteFrigobar> GetConsRestFrigs()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MConsumoRestauranteFrigobar.Include(c => c.Conta).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetConsRestFrig([FromQuery] int codConsumo)
    {
        using (var _context = new HotelProjetoContext())
        {
            var consumoRestauranteFrigobar = _context.MConsumoRestauranteFrigobar.Include(c => c.Conta)
            .FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (consumoRestauranteFrigobar == null)
            {
                return NotFound("Consumo não encontrado.");
            }
            return new ObjectResult(consumoRestauranteFrigobar);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MConsumoRestauranteFrigobar> PutConsRestFrig([FromForm] int codConsumo, [FromForm] int numeroConta, 
    [FromForm] string descricao, [FromForm] double valor, [FromForm] bool restauranteEntregaQuarto)
    {
        using (var _context = new HotelProjetoContext())
        {
            MConta? conta = _context.MConta.Include(c => c.Cliente).First(c => c.NumeroConta == numeroConta);

            if (conta == null)
            {
                return NotFound("Conta não encontrada!");
            }

            var consumoRestauranteFrigobar = _context.MConsumoRestauranteFrigobar.FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (consumoRestauranteFrigobar == null)
            {
                return NotFound("Consumo não encontrado!");
            }
            try
            {
                consumoRestauranteFrigobar.Conta = conta;
                consumoRestauranteFrigobar.Descricao = descricao;
                consumoRestauranteFrigobar.Valor = valor;
                consumoRestauranteFrigobar.RestauranteEntregaQuarto = restauranteEntregaQuarto;

                _context.SaveChanges();

                return Ok(consumoRestauranteFrigobar);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização do Consumo: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public IActionResult DeleteConsRestFrig([FromForm] int codConsumo)
    {
        using (var _context = new HotelProjetoContext())
        {
            var consumoRestauranteFrigobar = _context.MConsumoRestauranteFrigobar.FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (consumoRestauranteFrigobar == null)
            {
                return NotFound("Consumo não encontrado!");
            }
            _context.MConsumoRestauranteFrigobar.Remove(consumoRestauranteFrigobar);
            _context.SaveChanges();

            return Ok("Consumo excluído!");
        }
    }
}