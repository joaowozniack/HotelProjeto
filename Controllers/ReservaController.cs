using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProjeto;

[Route("api/[controller]")]
[ApiController]

public class ReservaController : Controller
{
    [HttpPost]
    public ActionResult<MReserva> PostReserva([FromForm] int numeroQuarto, [FromForm] int codFuncionario,
    [FromForm] int codCliente, [FromForm] DateOnly dataCheckin, [FromForm] DateOnly dataCheckout)
    {
        using (var _context = new HotelProjetoContext())
        {
            MQuarto? quarto = _context.MQuarto.Find(numeroQuarto);
            if (quarto == null)
            {
                return NotFound("Quarto não encontrado!");
            }
            MFuncionario? funcionario = _context.MFuncionario.Find(codFuncionario);
            if (funcionario == null){
                return NotFound("Funcionário não encontrado!");
            }
            MCliente? cliente = _context.MCliente.Find(codCliente);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            MReserva reserva = new MReserva(quarto, funcionario, cliente, dataCheckin, dataCheckout);
            _context.MReserva.Add(reserva);
            _context.SaveChanges();

            return Ok(reserva);
        }
    }

    [HttpGet]
    public List<MReserva> GetReservas()
    {
        using (var _context = new HotelProjetoContext())
        {
            return _context.MReserva.Include(r => r.Quarto).Include(r => r.Funcionario).Include(r => r.Cliente).ToList();
        }
    }

    [HttpGet("codigo")]
    public IActionResult GetReservaCod([FromQuery] int codReserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            var reserva = _context.MReserva.Include(r => r.Quarto).Include(r => r.Funcionario).Include(r => r.Cliente)
            .FirstOrDefault(r => r.CodReserva == codReserva);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada!");
            }
            return new ObjectResult(reserva);
        }
    }

    [HttpPut("codigo")]
    public ActionResult<MReserva> PutReserva([FromForm] int codReserva, [FromForm] int numeroQuarto, [FromForm] int codFuncionario,
    [FromForm] int codCliente, [FromForm] DateOnly dataCheckin, [FromForm] DateOnly dataCheckout)
    {
        using (var _context = new HotelProjetoContext())
        {
            MQuarto? quarto = _context.MQuarto.Find(numeroQuarto);
            if (quarto == null)
            {
                return NotFound("Quarto não encontrado!");
            }
            MFuncionario? funcionario = _context.MFuncionario.Find(codFuncionario);
            if (funcionario == null){
                return NotFound("Funcionário não encontrado!");
            }
            MCliente? cliente = _context.MCliente.Find(codCliente);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            var reserva = _context.MReserva.FirstOrDefault(r => r.CodReserva == codReserva);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada!");
            }
            
            try
            {
                reserva.Quarto = quarto;
                reserva.Funcionario = funcionario;
                reserva.Cliente = cliente;
                reserva.DataCheckin = dataCheckin;
                reserva.DataCheckout = dataCheckout;

                _context.SaveChanges();
                return Ok(reserva);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro na atualização da reserva: {ex.Message}");
            }
        }
    }

    [HttpDelete("codigo")]
    public ActionResult DeleteQuarto([FromForm] int codReserva)
    {
        using (var _context = new HotelProjetoContext())
        {
            var reserva = _context.MReserva.FirstOrDefault(r => r.CodReserva == codReserva);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada!");
            }
            _context.MReserva.Remove(reserva);
            _context.SaveChanges();

            return Ok("Reserva excluída!");
        }
    }
}