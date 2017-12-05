using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using apiCadastroCliente.Data;
using apiCadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Newtonsoft.Json.Serialization;

namespace apiCadastroCliente.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        
        private ClienteContexto clienteContexto;
        
        // GET api/cliente
        [Route("ListaClientes")]
        [HttpGet]
        public IEnumerable<ClienteModel> ListaClientes()
        {
            using (var ctx = new ClienteContexto())
            {
                return  ctx.Clientes.ToList();
            }  
        }

        // GET api/cliente/5
        [Route("Id")]
        [HttpGet("Id/{id}")]
        public ClienteModel Id(int id)
        {
            var ctx = FiltraCliente(id);

            var c = ctx.First();
            
            return c;
        }

        // POST api/cliente
        [Route("Novo")]
        [HttpPost]
        public void Novo([FromBody] string value)
        {
            var c = value;

        }

        // PUT api/cliente/5
        [Route("Update")]
        [HttpPut("Update/{id}")]
        public bool Update(int id,[FromBody] ClienteModel cliente)
        {

            //var cliente = (JsonObject<ClienteModel>) value;
            
            //var c = FiltraCliente(cliente.Object.ID).First();
            /*
            if (ModelState.IsValid)
            {
                using (var ctx = new ClienteContexto())
                {
                    c.Nome = cliente.Object.Nome;
                    c.Bairro = cliente.Object.Bairro;
                    c.CEP = cliente.Object.CEP;
                    c.Cidade = cliente.Object.Cidade;
                    c.Endereco = cliente.Object.Endereco;
                    c.Status = cliente.Object.Status;
                    c.Uf = cliente.Object.Uf;
                    

                    ctx.Clientes.Update(c);
                    ctx.SaveChangesAsync();

                }
                return true;
            }
            */
            return true;
            
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {   
            
            var c = FiltraCliente(id).First();
            
            using (var ctx = new ClienteContexto())
            {
                ctx.Clientes.Remove(c);
                ctx.SaveChangesAsync();
            }
            
            return true;
        }
        
        public IEnumerable<ClienteModel> FiltraCliente(int id)
        {
            using (var ctx = new ClienteContexto())
            {
                return ctx.Clientes.Where(c => c.ID == id).ToList();
            }
            

        }
        
        
    }
}