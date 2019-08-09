using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Services.REST.ClienteAPI.Controllers
{
    [EnableCors(origins: "http://mywebcliente.azurewebsites.net", headers: "*", methods: "*")]

    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        
        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> Get()
        {
            return _clienteAppService.ObterTodos();
        }

        // GET: api/Clientes/5
        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        // Post tem intenção de enviar algo novo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        // Put tem a intenção de enviar algo que já existe
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
