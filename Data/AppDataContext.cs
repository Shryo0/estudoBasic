using Microsoft.EntityFrameworkCore;
using Prova.Models;
namespace Prova.Data
{
    // Classe responsável pelo contexto do banco de dados
    public class AppDataContext : DbContext
    {
        // Construtor que recebe as opções do DbContext
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) {}

        // Definindo as entidades do banco de dados como propriedades DbSet
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        // Método chamado durante a criação do modelo, utilizado para configurações específicas
         protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Preenchendo dados iniciais para a tabela Cliente
    modelBuilder.Entity<Cliente>().HasData(
        new Cliente { ClienteId = 1, Nome = "João Silva" },
        new Cliente { ClienteId = 2, Nome = "Maria Oliveira" },
        new Cliente { ClienteId = 3, Nome = "José Santos" }
    );

    // Preenchendo dados iniciais para a tabela Pedido
    modelBuilder.Entity<Pedido>().HasData(
        new Pedido { PedidoId = 1, Nome = "Pedido 1", Descricao = "Descrição do Pedido 1", ClienteId = 1, CriadoEm = DateTime.Now.AddDays(1) },
        new Pedido { PedidoId = 2, Nome = "Pedido 2", Descricao = "Descrição do Pedido 2", ClienteId = 2, CriadoEm = DateTime.Now.AddDays(2) },
        new Pedido { PedidoId = 3, Nome = "Pedido 3", Descricao = "Descrição do Pedido 3", ClienteId = 3, CriadoEm = DateTime.Now.AddDays(3) }
    );

    // O restante do seu código...
}
 }}
