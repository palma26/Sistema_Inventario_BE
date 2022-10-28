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
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursal Isucursal;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new(); 

        public SucursalesController(ISucursal isucursal, IMapper _mapper)
        {
            Isucursal = isucursal;
            mapper = _mapper;   
        }

        //Api para obtener sucursales
        [HttpGet("[action]")]
        public IActionResult GetSucursales()
        {
            try
            {
                var sucursales = Isucursal.GetSucursales();
                return Ok(sucursales);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener las sucursales";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar sucursales
        [HttpPost("[action]")]
        public IActionResult AddSucursal([FromBody] SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = mapper.Map<Sucursal>(sucursalDto);
                Isucursal.AddSucursal(sucursal);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la sucursal " + sucursalDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la sucursal " + sucursalDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar empresas
        [HttpPatch("[action]")]
        public IActionResult UpdateSucursal([FromBody] SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = mapper.Map<Sucursal>(sucursalDto);
                Isucursal.UpdateSucursal(sucursal);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actualizaron los datos para la sucursal " + sucursalDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar los datos para la sucursal " + sucursalDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja una sucursal 
        [HttpPatch("[action]/{IdSucursal}")]
        public IActionResult DeleteSucursal(int IdSucursal)
        {
            try
            {
                var sucursal = Isucursal.GetSucursal(IdSucursal);
                Isucursal.DeleteSucursal(sucursal);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "La sucursal " + sucursal.Nombre + " fue eliminada";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar la sucursal ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
