using System.ComponentModel.DataAnnotations;

namespace apiCadastroCliente.Models
{
    public class ClienteModel
    {
        
        [Key]
        public int ID { get; set; }
       
        [MaxLength(40, ErrorMessage = "O nome deve conter no máxino 40 caracters")]
        public string Nome { get; set; }
        
        [MaxLength(10, ErrorMessage = "O CEP deve conter no máxino 10 caracters")]
        public string CEP { get; set; }
        
        [MaxLength(40, ErrorMessage = "O Endereço deve conter no máxino 40 caracters")]
        public string Endereco { get; set; }
        
        [MaxLength(30, ErrorMessage = "O Bairro deve conter no máxino 30 caracters")]
        public string Bairro { get; set; }
        
        [MaxLength(40, ErrorMessage = "O Cidade deve conter no máxino 40 caracters")]
        public string Cidade { get; set; }
        
        [MaxLength(2, ErrorMessage = "O UF deve conter no máxino 2 caracters")]
        public string Uf { get; set; }
        
        public bool Status { get; set; }
        
    }
}