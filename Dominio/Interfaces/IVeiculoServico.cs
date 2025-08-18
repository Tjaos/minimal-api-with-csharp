namespace MinimalApi.Dominio.Interfaces;

using System.Collections.Generic;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null);
    Veiculo? BuscaPorId(int id);
    void Incluir(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Excluir(Veiculo veiculo);
}