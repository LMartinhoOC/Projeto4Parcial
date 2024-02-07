using Entity.API.ViewModels;
using Entity.Dados.Interface;
using Entity.Entidades;
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
        private readonly IClientePersistence _clientePersistence;

        public ClienteController(IClientePersistence clientePersistence)
        {
            this._clientePersistence = clientePersistence;
        }


        [HttpGet]
        [Route("clientes")]
        public ActionResult Cliente()
        {
            try
            {
                List<Cliente> clientes = this._clientePersistence
                    .ObterClientes();

                return Ok(clientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }            
        }


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Cliente(int id)
        {
            try
            {
                Cliente cliente = this._clientePersistence
                    .ObterClientePorId(id);

                if (cliente == null) 
                {
                    return NotFound($"Não existe o cliente com o Id fornecido: {id}");
                }                

                return Ok(cliente);

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpPost]
        [Route("")]
        public ActionResult Cliente(ClienteInserirViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Cliente cliente        = new Cliente();
                    cliente.Nome           = model.Nome;
                    cliente.Email          = model.Email;
                    cliente.DataNascimento = model.DataNascimento;

                    this._clientePersistence
                        .InserirCliente(cliente);

                    return Ok(cliente);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpPut]
        [Route("")]
        public ActionResult Cliente(ClienteAtualizarViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Cliente cli = this._clientePersistence
                        .ObterClientePorId(model.Id);

                    if (cli == null)
                    {
                        return NotFound($"O cliente com o Id: {model.Id} não existe.");
                    }
                    else
                    {
                        Cliente cliente        = new Cliente();
                        cliente.Id             = model.Id;
                        cliente.Nome           = model.Nome;
                        cliente.Email          = model.Email;
                        cliente.DataNascimento = model.DataNascimento;

                        this._clientePersistence
                            .AtualizarCliente(cliente);

                        return Ok(cliente);
                    }                   
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeletarCliente(int id)
        {
            try
            {
                
                Cliente cli = this._clientePersistence
                        .ObterClientePorId(id);

                if (cli == null)
                {
                   return NotFound($"O cliente com o Id: {id} não existe.");
                }
                else
                {
                    this._clientePersistence.DeletarCliente(cli);

                    //Pode retornar tanto o status 200 quanto o 204 no caso de exclusão
                    //return Ok(cli);
                    return NoContent();  
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
