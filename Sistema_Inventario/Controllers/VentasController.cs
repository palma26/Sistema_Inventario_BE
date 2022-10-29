using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Inventario.DtoModels;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using Sistema_Inventario.Utilis;

namespace Sistema_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVenta Iventa;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public VentasController(IVenta iventa, IMapper _mapper)
        {
            Iventa = iventa;
            mapper = _mapper;   
        }

        //Api para agregar ventas
        [HttpPost("[action]")]
        public IActionResult AddVenta([FromBody] VentaDto ventaDto)
        {
            try
            {
                var venta = mapper.Map<Venta>(ventaDto);
                Iventa.AddVenta(venta);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la vventa";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la venta";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        [HttpGet("[action]")]
        public IActionResult NotasCredito()
        {
            try
            {
                var notasCredito = Iventa.GetNotasCreditos();

                return Ok(notasCredito);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la obtener notas credito";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        [HttpGet("[action]")]
        public IActionResult NotasDebito()
        {
            try
            {
                var notasDebito = Iventa.GetNotasDebitos();

                return Ok(notasDebito);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la obtener notas credito";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
