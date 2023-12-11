namespace Prova.Models;
public class Pedido{
    public int PedidoId {get; set;}
    public String? Nome {get; set;}
    public String? Descricao {get; set;}
    public int ClienteId {get; set;}
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public Cliente? Cliente { get; set; }
    
}