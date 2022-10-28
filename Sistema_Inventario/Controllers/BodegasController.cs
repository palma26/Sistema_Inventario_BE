using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Inventario.DtoModels;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using Sistema_Inventario.Utilis;

namespace Sistema_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly IBodega Ibodega;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public BodegasController(IBodega ibodega, IMapper mapper)
        {
            Ibodega = ibodega;
            this.mapper = mapper;
        }

        //Api para obtener listado de bodegas
        [HttpGet("[action]")]
        public IActionResult GetBodegas()
        {
            try
            {
                var bodegas = Ibodega.GetBodegas();
                return Ok(bodegas);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener las bodegas";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar bodegas
        [HttpPost("[action]")]
        public IActionResult AddBodega([FromBody] BodegaDto bodegaDto)
        {
            try
            {
                var bodega = mapper.Map<Bodega>(bodegaDto);
                Ibodega.AddBodega(bodega);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la bodega " + bodegaDto.Descripcion;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la bodega " + bodegaDto.Descripcion;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar datos de bodegas
        [HttpPatch("[action]")]
        public IActionResult UpdateBodega([FromBody] BodegaDto bodegaDto)
        {
            try
            {
                var bodega = mapper.Map<Bodega>(bodegaDto);
                Ibodega.UpdateBodega(bodega);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actualizaron los datos para la bodega " + bodegaDto.Descripcion;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar los datos para la bodega " + bodegaDto.Descripcion;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja una bodega 
        [HttpPatch("[action]/{IdBodega}")]
        public IActionResult DeleteBodega(int IdBodega)
        { 
            try
            {
                var bodega = Ibodega.GetBodega(IdBodega);
                Ibodega.DeleteBodega(bodega);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "La bodega " + bodega.Descripcion + " fue eliminada";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar la bodega ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
