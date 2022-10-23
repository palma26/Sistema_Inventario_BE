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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresa Iempresa;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();

        public EmpresasController(IEmpresa iempresa, IMapper _mapper)
        {
            Iempresa = iempresa;
            mapper = _mapper;
        }

        //Api para obtener listado de empresas activas 
        [HttpGet("[action]")]
        public IActionResult GetEmpresas()
        {
            try
            {
                var empresas = Iempresa.GetEmpresas();
                var empresasDto = mapper.Map<List<EmpresaDto>>(empresas);

                return Ok(empresasDto);
            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener las empresas";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para agregar empresas
        [HttpPost("[action]")]
        public IActionResult AddEmpresa([FromBody] EmpresaDto empresaDto)
        {
            try
            {
                var empresa = mapper.Map<Empresa>(empresaDto);
                Iempresa.AddEmpresa(empresa);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se agrego la empresa " + empresaDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al agregar la empresa "+empresaDto.Nombre;
                responseMessage.ResultMessage = "Error interno "+ e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para editar empresas
        [HttpPut("[action]")] 
        public IActionResult UpdateEmpresa([FromBody] EmpresaDto empresaDto)
        {
            try
            {
                var empresa = mapper.Map<Empresa>(empresaDto);
                Iempresa.UpdtaeEmpresa(empresa);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "Se actulizaron los datos para la empresa " + empresaDto.Nombre;
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al editar datos de la empresa " + empresaDto.Nombre;
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        //Api para dar de baja una empresa
        [HttpPut("[action]/{IdEmpresa}")]
        public IActionResult DeleteEmpresa(int IdEmpresa)
        {
            try
            {
                var empresa = Iempresa.GetEmpresa(IdEmpresa);
                Iempresa.DeleteEmpresa(empresa);

                responseMessage.CodigoResult = "00";
                responseMessage.Message = "La empresa " + empresa.Nombre + " fue eliminada";
                responseMessage.ResultMessage = "EXITO";

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al eliminar la empresa ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
