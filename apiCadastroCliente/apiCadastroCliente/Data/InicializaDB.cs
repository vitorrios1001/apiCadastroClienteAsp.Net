using System.Linq;
using apiCadastroCliente.Models;

namespace apiCadastroCliente.Data
{
    public class InicializaDB
    {
        public static void Inicializa(ClienteContexto contexo)
        {

            contexo.Database.EnsureCreated();
            
            if (contexo.Clientes.Any())
            {
                return;  
            }
            
            var clientes = new ClienteModel[]
            {
                new ClienteModel
                {
                    ID = 1,
                    Nome = "Vitor",
                    CEP = "75400000",
                    Endereco = "Rua 02",
                    Bairro = "Japao",
                    Cidade = "Goiania",
                    Uf = "GO",
                    Status = true
                }
            };
            
            foreach (var cliente in clientes)
            {
                contexo.Clientes.Add(cliente);
            }
            
            
            contexo.SaveChanges();

        }
        
        
        
        
        
        
        
    }
}