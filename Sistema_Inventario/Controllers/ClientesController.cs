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
    public class ClientesController : ControllerBase
    {
        private readonly ICliente Icliente;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public ClientesController(ICliente icliente, IMapper _mapper)
        {
            Icliente = icliente;
            mapper = _mapper;
        }

        //Api para obtener todos los clientes activos
        [HttpGet("[action]")]
        public IActionResult GetClientes()
        {
            try
            {
                var clientes = Icliente.GetClientes();
                var clientesDto = mapper.Map<List<ClienteDto>>(clientes);

                return Ok(clientesDto);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener los clientes";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar clientes
        [HttpPost("[action]")]
        public IActionResult AddCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(clienteDto);
                Icliente.AddCliente(cliente);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego con exito a " + cliente.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar a " + clienteDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar datos de los clientes
        [HttpPut("[action]")]
        public IActionResult UpdateCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(clienteDto);
                Icliente.UpdateCliente(cliente);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actualizaron con exito los datos de " + cliente.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e) 
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar los datos de " + clienteDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja a clientes
        [HttpPut("[action]/{IdCliente}")]
        public IActionResult DeleteCliente(int IdCliente)
        {
            try
            {
                var cliente = Icliente.GetCliente(IdCliente);
                Icliente.DeleteCliente(cliente);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se elimino a "+cliente.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar al cliente ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
