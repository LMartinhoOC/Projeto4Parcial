using Entity.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("clientes")]
        public ActionResult Cliente()
        {
            return null;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Cliente(int id)
        {
            return null;
        }


        [HttpPost]
        [Route("")]
        public ActionResult Cliente(ClienteInserirViewModel model)
        {
            return null;
        }


        [HttpPut]
        [Route("")]
        public ActionResult Cliente(ClienteAtualizarViewModel model)
        {
            return null;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeletarCliente(int id)
        {
            return null;
        }
    }
}
