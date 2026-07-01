using System;
using CadastroProdutos.Database;

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
        banco.Produtos.Add(novoProduto);
        banco.SaveChanges();
    }

    public Produto Atualizar(int id, Produto produtoAtualizado)
    {
        throw new NotImplementedException();
    }

    public Produto ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Produto> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public bool Remover(int id)
    {
        throw new NotImplementedException();
    }
}