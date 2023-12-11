using Prova.Data;
using Prova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Prova.Controllers
{
    // Controlador responsável pelas operações relacionadas à entidade Pedido
    [ApiController]
    [Route("Prova/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        // Construtor que injeta o contexto do banco de dados
        public PedidoController(AppDataContext context)
        {
            _ctx = context;
        }
        // Endpoint para listar todos os pedidos
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                // Recupera todos os pedidos do banco de dados, incluindo a categoria de cada pedido
                List<Pedido> pedidos = _ctx.Pedidos.Include(x => x.Cliente).ToList();
                // Retorna resposta NotFound se nenhum pedido for encontrado; caso contrário, retorna os pedidos
                return pedidos.Count == 0 ? NotFound() : Ok(pedidos);
            }
            catch (Exception e)
            {
                // Retorna uma resposta BadRequest em caso de erro
                return BadRequest(e.Message);
            }
        }
        // Endpoint para buscar um pedido pelo ID
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            try
            {
                // Busca um pedido pelo ID, incluindo a categoria
                Pedido? pedidoCadastrado = _ctx.Pedidos.Include(x => x.Cliente).FirstOrDefault(x => x.PedidoId == id);
                // Retorna NotFound se o pedido não for encontrado; caso contrário, retorna o pedido
                return pedidoCadastrado != null ? Ok(pedidoCadastrado) : NotFound();
            }
            catch (Exception e)
            {
                // Retorna BadRequest em caso de erro
                return BadRequest(e.Message);
            }
        }
        // Endpoint para cadastrar um novo pedido
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Pedido pedido)
        {
            try
            {
                // Verifica se a categoria associada ao pedido existe
                Cliente? cliente = _ctx.Clientes.Find(pedido.ClienteId);
                if (cliente == null)
                {
                    return NotFound();
                }

                // Associa a categoria ao pedido, adiciona o pedido ao contexto e salva as alterações
                pedido.Cliente = cliente;
                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();

                // Retorna Created com o pedido cadastrado
                return Created("", pedido);
            }
            catch (Exception e)
            {
                // Retorna BadRequest em caso de erro
                return BadRequest(e.Message);
            }
        }

        // Endpoint para alterar os detalhes de um pedido (normal)
        [HttpPost]
        [Route("alterar/{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] Pedido pedido)
        {
            try
            {
                // Busca o pedido pelo ID
                Pedido? pedidoCadastrado = _ctx.Pedidos.FirstOrDefault(x => x.PedidoId == id);

                if (pedidoCadastrado != null)
                {
                    // Verifica se a nova categoria associada ao pedido existe
                    Cliente? cliente = _ctx.Clientes.Find(pedido.ClienteId);
                    if (cliente == null)
                    {
                        return NotFound();
                    }
                    // Atualiza os detalhes do pedido com os novos valores e salva as alterações
                    pedidoCadastrado.Nome = pedido.Nome;
                    pedidoCadastrado.Cliente = cliente;
                    pedidoCadastrado.Descricao = pedido.Descricao;
                    _ctx.Pedidos.Update(pedidoCadastrado);
                    _ctx.SaveChanges();

                    // Retorna Ok se a operação for bem-sucedida
                    return Ok();
                }
                // Retorna NotFound se o pedido não for encontrado
                return NotFound();
            }
            catch (Exception e)
            {
                // Retorna BadRequest em caso de erro
                return BadRequest(e.Message);
            }
        }
        
/*  
{ "pedidoId": 1,  // Substitua pelo ID do pedido que você deseja alterar
  "nome": "Pedido Atualizado",
  "descricao": "Descrição Atualizada",
  "clienteId": 1,  // Substitua pelo ID do cliente associado ao pedido
  "criadoEm": "2023-12-11T06:36:04.382Z",
  "cliente": {
    "clienteId": 1,  // Substitua pelo ID do cliente
    "nome": "Cliente Atualizado"
  }
}
 */
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            try
            {
                // Busca o pedido pelo ID
                Pedido? pedidoCadastrado = _ctx.Pedidos.Find(id);

                if (pedidoCadastrado != null)
                {
                    // Remove o pedido do contexto e salva as alterações
                    _ctx.Pedidos.Remove(pedidoCadastrado);
                    _ctx.SaveChanges();

                    // Retorna a lista atualizada de pedidos
                    return Ok(_ctx.Pedidos.Include(x => x.Cliente).ToList());
                }

                // Retorna NotFound se o pedido não for encontrado
                return NotFound();
            }
            catch (Exception e)
            {
                // Retorna StatusCode 500 (Internal Server Error) em caso de erro
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error");
            }}}}
