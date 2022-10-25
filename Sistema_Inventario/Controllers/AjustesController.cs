using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
