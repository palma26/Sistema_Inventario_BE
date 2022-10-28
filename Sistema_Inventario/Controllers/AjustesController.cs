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
    public class AjustesController : ControllerBase
    {
        private readonly IAjuste Iajuste;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public AjustesController(IAjuste iajuste, IMapper _mapper)
        {
            Iajuste = iajuste;
            mapper = _mapper;
        }

        //Api para obtener listado de ajustes
        [HttpGet("[action]")]
        public IActionResult GetAjustes()
        {
            try
            {
                var ajustes = Iajuste.GetAjustes();

                return Ok(ajustes);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener los ajustes";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar ajustes
        [HttpPost("[action]")]
        public IActionResult AddAjuste([FromBody] AjusteDto ajusteDto)
        {
            try
            {
                var ajuste = mapper.Map<Ajuste>(ajusteDto);
                Iajuste.AddAjuste(ajuste);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego el ajuste ";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la el ajuste ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar ajustes
        [HttpPatch("[action]")]
        public IActionResult UpdateAjuste([FromBody] AjusteDto ajusteDto)
        {
            try
            {
                var ajuste = mapper.Map<Ajuste>(ajusteDto);
                Iajuste.UpdateAjuste(ajuste);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actulizaron los datos del ajuste ";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar datos del ajuste ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja ajustes
        [HttpPatch("[action]/{IdAjuste}")]
        public IActionResult DeleteAjuste(int IdAjuste)
        {
            try
            {
                var ajuste = Iajuste.GetAjuste(IdAjuste);
                Iajuste.DeleteAjuste(ajuste);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "El ajuste fue eliminado";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar el ajustte ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
