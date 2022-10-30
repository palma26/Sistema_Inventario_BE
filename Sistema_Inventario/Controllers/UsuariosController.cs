using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using Sistema_Inventario.Utilis;

namespace Sistema_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario Iusuario;
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage = new();
         
        public UsuariosController(IUsuario iuser, IMapper _mapper)
        {
            Iusuario = iuser;
            mapper = _mapper;
        }

        //Api para obtener listado de bodegas
        [HttpGet("[action]/{user}")]
        public IActionResult LOGIN(string user)
        {
            try
            {
                var usuario = Iusuario.GetUsuario(user);
                return Ok(usuario);

            }
            catch (Exception e)
            {
                responseMessage.CodigoResult = "99";
                responseMessage.Message = "Ha ocurrido un error al obtener el usuario ";
                responseMessage.ResultMessage = "Error interno " + e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
