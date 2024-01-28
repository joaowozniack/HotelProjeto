using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ConsumoRestauranteFrigobarController : Controller
{
    [HttpPost]
    public void PostConsRestFrig([FromBody] MConsumoRestauranteFrigobar consumoRestauranteFrigobar)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MConsumoRestauranteFrigobar.Add(consumoRestauranteFrigobar);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MConsumoRestauranteFrigobar> GetConsRestFrigs()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MConsumoRestauranteFrigobar.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetConsRestFrig([FromQuery] int codConsumo)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConsumoRestauranteFrigobar.FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (item == null)
            {
                return NotFound("Consumo não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutConsRestFrig([FromQuery] int codConsumo, [FromBody] MConsumoRestauranteFrigobar consumo)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConsumoRestauranteFrigobar.FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(consumo);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteConsRestFrig([FromQuery] int codConsumo)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MConsumoRestauranteFrigobar.FirstOrDefault(c => c.CodConsumo == codConsumo);
            if (item == null)
            {
                return;
            }
            _context.MConsumoRestauranteFrigobar.Remove(item);
            _context.SaveChanges();
        }
    }
}