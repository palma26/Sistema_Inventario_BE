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
    public class ComprasController : ControllerBase
    {
        private readonly ICompra Icompra;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public ComprasController(ICompra icompra, IMapper _mapper)
        {
            Icompra = icompra;
            mapper = _mapper;   
        }


        //Api para agregar compras
        [HttpPost("[action]")]
        public IActionResult AddCompra([FromBody] CompraDto compraDto)
        {
            try
            {
                var compra = mapper.Map<Compra>(compraDto);
                Icompra.AddCompra(compra);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la compra";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar lacompra";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
