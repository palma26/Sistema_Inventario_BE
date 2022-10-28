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
    public class ProductosController : ControllerBase
    {
        private readonly IProducto Iproducto;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public ProductosController(IProducto iproducto, IMapper _mapper)
        {
            Iproducto = iproducto;
            mapper = _mapper;
        }

        //Api para obtener productos 
        [HttpGet("[action]")]
        public IActionResult GetProductos()
        {
            try
            {
                var productos = Iproducto.GetProductos();
                return Ok(productos);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener los productos ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //api para agregar productos 
        [HttpPost("[action]")]
        public IActionResult AddProductos([FromBody] ProductoDto productoDto)
        {
            try
            {
                var producto = mapper.Map<Producto>(productoDto);
                Iproducto.AddProducto(producto);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego el producto " + productoDto.Descripcion;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar el producto " + productoDto.Descripcion;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar datos de productos 
        [HttpPatch("[action]")]
        public IActionResult UpdateProducto([FromBody] ProductoDto productoDto)
        {
            try
            {
                var producto = mapper.Map<Producto>(productoDto);
                Iproducto.EditProducto(producto);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actulizaron los datos con exito ";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar datos ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja productos
        [HttpPatch("[action]/{IdProducto}")]
        public IActionResult DeleteProductos(int IdProducto)
        {
            try
            {
                var producto = Iproducto.GetProducto(IdProducto);
                Iproducto.DeleteProducto(producto);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "El producto fue eliminado ";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar el producto ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
