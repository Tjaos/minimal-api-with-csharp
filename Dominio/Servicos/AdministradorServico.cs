using System.Data.Common;
using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Interfaces;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }
    
    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Administradores.AsQueryable();

        int itensPorPagina = 10;

        query = query.Skip(((pagina ?? 1) - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }

        
    }