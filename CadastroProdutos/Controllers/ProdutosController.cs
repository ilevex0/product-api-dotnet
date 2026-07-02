using CadastroProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CadastroProdutos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutosService produtosService;
        public ProdutosController(IProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.ObterTodos());
        }
        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
            {
                return NotFound($"Produto com ID {id} não encontrado.");
            }

            return Ok(produto);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            try
            {
                produtosService.Adicionar(novoProduto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, Produto produtoAtualizado)
        {
            try
            {
                var produto = produtosService.Atualizar(id, produtoAtualizado);

                if(produto is null)
                {
                    return NotFound($"Produto com id {id} não encontrado.");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletou = produtosService.Remover(id);

            if(deletou == false)
            {
                return NotFound($"Produto com id {id} não encontrado.");
            }

            return NoContent();
        }
    }
}