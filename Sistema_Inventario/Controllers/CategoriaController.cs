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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria Icategoria;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public CategoriaController(ICategoria icategoria, IMapper _mapper)
        {
            Icategoria = icategoria;
            mapper = _mapper;
        }

        //Api para obtener listado de categorias
        [HttpGet("[action]")]
        public IActionResult GetCategorias()
        {
            try
            {
                var categorias = Icategoria.GetCategorias();
                var categoriasDto = mapper.Map<List<CategoriaDto>>(categorias);

                return Ok(categoriasDto);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener las categorias";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar categorias
        [HttpPost("[action]")]
        public IActionResult AddCategoria([FromBody] CategoriaDto categoriaDto)
        {
            try
            {
                var categoria = mapper.Map<Categoria>(categoriaDto);
                Icategoria.AddCategoria(categoria);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la categoria " + categoriaDto.Descripcion;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la categoria " + categoriaDto.Descripcion;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar categorias
        [HttpPatch("[action]")]
        public IActionResult UpdateCategoria([FromBody] CategoriaDto categoriaDto)
        {
            try
            {
                var categoria = mapper.Map<Categoria>(categoriaDto);
                Icategoria.UpdateCategoria(categoria);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se editaron los datos para la categoria " + categoriaDto.Descripcion;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar los datos para la categoria " + categoriaDto.Descripcion;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja categorias 
        [HttpPatch("[action]/{IdCategoria}")]
        public IActionResult DeleteCategoria(int IdCategoria)
        {
            try
            {
                var categoria = Icategoria.GetCategoria(IdCategoria);
                Icategoria.DeleteCategoria(categoria);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "La categoria " + categoria.Descripcion + " fue eliminada";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar la categoria ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
