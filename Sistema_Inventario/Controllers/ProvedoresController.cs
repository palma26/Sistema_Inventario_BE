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
    public class ProvedoresController : ControllerBase
    {
        private readonly IProveedor Iproveedor;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public ProvedoresController(IProveedor iproveedor, IMapper _mapper)
        {
            Iproveedor = iproveedor;
            mapper = _mapper;
        }

        //Metodo para obtener proveedores
        [HttpGet("[action]")]
        public IActionResult GetProveedores()
        {
            try
            {
                var proveedores = Iproveedor.GetProveedores();
                var proveedoresDto = mapper.Map<List<ProveedorDto>>(proveedores);

                return Ok(proveedoresDto);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener los proveedores ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar proveedores
        [HttpPost("[action]")]
        public IActionResult AddProveedor([FromBody] ProveedorDto proveedorDto)
        {
            try
            {
                var proveedor = mapper.Map<Proveedor>(proveedorDto);
                Iproveedor.AddProveedor(proveedor);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego a " + proveedorDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar a " + proveedorDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar datos de proveedores
        [HttpPut("[action]")]
        public IActionResult UpdateProveedor([FromBody] ProveedorDto proveedorDto)
        {
            try
            {
                var proveedor = mapper.Map<Proveedor>(proveedorDto);
                Iproveedor.UpdateProveedor(proveedor);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actualizaron los datos de " + proveedorDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al actualizar los datos de " + proveedorDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja a proveedores
        [HttpPut("[action]/{IdProveedor}")]
        public IActionResult DeleteProveedor(int IdProveedor)
        {
            try
            {
                var proveedor = Iproveedor.GetProveedor(IdProveedor);
                Iproveedor.DeleteProveedor(proveedor);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se dio de baja a " + proveedor.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar al proveedor ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
