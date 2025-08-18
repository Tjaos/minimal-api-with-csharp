using System.Data.Common;
using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Interfaces;

namespace MinimalApi.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto) => _contexto = contexto;

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => v.Nome.ToLower().Contains(nome.ToLower()));
        }

        int itensPorPagina = 10;

        if (!string.IsNullOrEmpty(marca))
        {
            query = query.Where(v => v.Marca.ToLower().Contains(marca.ToLower()));
        }

        return query.Skip(((pagina ?? 1) - 1) * itensPorPagina).Take(itensPorPagina).ToList();
    }

    public Veiculo? BuscaPorId(int id)
    {

        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public void Excluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }
}