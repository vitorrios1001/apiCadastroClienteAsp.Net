using Microsoft.EntityFrameworkCore;
using apiCadastroCliente.Models;

namespace apiCadastroCliente.Data
{
    public class ClienteContexto : DbContext
    {
        
        public ClienteContexto()
        {
            
        }
        
        public ClienteContexto(DbContextOptions<ClienteContexto> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().ToTable("Clientes");      

            base.OnModelCreating(modelBuilder);
        }
        
        public static string ConnectionString { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            ConnectionString = "server=localhost;port=3306;database=ClienteContexto;user=root;password=root";
            
            optionsBuilder.UseMySql(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
        
        
    }
}