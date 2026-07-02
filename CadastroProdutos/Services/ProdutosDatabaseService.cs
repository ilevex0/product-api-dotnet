using System;
using CadastroProdutos.Database;
using CadastroProdutos.Models;

namespace CadastroProdutos.Services;

public class ProdutosDatabaseService : IProdutosService
{
    private ApplicationDbContext banco;

    public ProdutosDatabaseService(ApplicationDbContext banco)
    {
        this.banco = banco;
    }

    public void Adicionar(Produto novoProduto)
    {
        ValidarProdutos(novoProduto);
        banco.Produtos.Add(novoProduto);
        banco.SaveChanges();
    }

    public Produto Atualizar(int id, Produto produtoAtualizado)
    {
        ValidarProdutos(produtoAtualizado);
        var produto = banco.Produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;
        banco.SaveChanges();

        return produto;
    }

    public Produto ObterPorId(int id)
    {
        return banco.Produtos.FirstOrDefault(x => x.Id == id);
    }

    public List<Produto> ObterTodos()
    {
        return banco.Produtos.ToList();
    }

    public bool Remover(int id)
    {
        var produto = banco.Produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return false;
        }

        banco.Produtos.Remove(produto);
        banco.SaveChanges();

        return true;
    }

    private void ValidarProdutos(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new Exception("O nome do produto é obrigatório.");
        }
        if (produto.Preco <= 0)
        {
            throw new Exception("O preço do produto deve ser maior que zero.");
        }
        if (produto.Estoque < 0)
        {
            throw new Exception("O estoque do produto não pode ser negativo.");
        }
        if (produto.Estoque > 1000)
        {
            throw new Exception("O estoque do produto não pode ser maior que 1000.");
        }
        
    }
}