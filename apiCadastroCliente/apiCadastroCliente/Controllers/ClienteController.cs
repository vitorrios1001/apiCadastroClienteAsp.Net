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
        
        // GET api/cliente/ListaClientes
        [Route("ListaClientes")]
        [HttpGet]
        public IEnumerable<ClienteModel> ListaClientes()
        {
            using (var ctx = new ClienteContexto())
            {
                return  ctx.Clientes.ToList();
            }  
        }

        // GET api/cliente/id/5
        [Route("Id")]
        [HttpGet("Id/{id}")]
        public ClienteModel Id(int id)
        {
            var ctx = FiltraCliente(id);

            var c = ctx.First();
            
            return c;
        }

        // POST api/cliente/Novo
        [Route("Novo")]
        [HttpPost]
        public ClienteModel Novo([FromBody] ClienteModel cliente)
        {
            var c = new ClienteModel();
            
            if (ModelState.IsValid)
            {
                using (var ctx = new ClienteContexto())
                {
                    c.Nome = cliente.Nome;
                    c.Bairro = cliente.Bairro;
                    c.CEP = cliente.CEP;
                    c.Cidade = cliente.Cidade;
                    c.Endereco = cliente.Endereco;
                    c.Status = cliente.Status;
                    c.Uf = cliente.Uf;
                    

                    ctx.Clientes.Update(c);
                    ctx.SaveChangesAsync();
                    return c;
                }
                
            }
            return c;

        }

        // PUT api/cliente/Update/5
        [Route("Update")]
        [HttpPut("Update/{id}")]
        public ClienteModel Update(int id,[FromBody] ClienteModel cliente)
        {
            
            var c = FiltraCliente(id).First();
            
            if (ModelState.IsValid)
            {
                using (var ctx = new ClienteContexto())
                {
                    c.Nome = cliente.Nome;
                    c.Bairro = cliente.Bairro;
                    c.CEP = cliente.CEP;
                    c.Cidade = cliente.Cidade;
                    c.Endereco = cliente.Endereco;
                    c.Status = cliente.Status;
                    c.Uf = cliente.Uf;
                    

                    ctx.Clientes.Update(c);
                    ctx.SaveChangesAsync();
                    return c;
                }
                
            }
            return c;


        }

        // DELETE api/cliente/Delete/5
        [Route("Delete")]
        [HttpDelete("delete/{id}")]
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