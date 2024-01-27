using Microsoft.AspNetCore.Mvc;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ReservaController : Controller
{
    [HttpPost]
    public void PostReserva([FromBody] MReserva reserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            _context.MReserva.Add(reserva);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<MFuncionario> GetReservas()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MFuncionario.ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetReservaCod([FromQuery] int codReserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MReserva.FirstOrDefault(r => r.codReserva == codReserva);
            if (item == null)
            {
                return NotFound("Reserva não encontrado.");
            }
            return new ObjectResult(item);
        }
    }

    [HttpPut("codigo")]
    public void PutReserva([FromQuery] int codReserva, [FromBody] MReserva reserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MReserva.FirstOrDefault(t => t.codReserva == codReserva);
            if (item == null)
            {
                return;
            }
            _context.Entry(item).CurrentValues.SetValues(reserva);
            _context.SaveChanges();
        }
    }

    [HttpDelete("codigo")]
    public void DeleteFuncionario([FromQuery] int codReserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            var item = _context.MReserva.FirstOrDefault(f => f.codReserva == codReserva);
            if (item == null)
            {
                return;
            }
            _context.MReserva.Remove(item);
            _context.SaveChanges();
        }
    }
}