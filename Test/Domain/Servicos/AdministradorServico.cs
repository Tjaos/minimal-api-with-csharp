
using System.Data.SqlTypes;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTeste
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..", "appsettings.json"));

        var builder = new ConfigurationBuilder().SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        //Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
        var administradorServico = new AdministradorServico(context);

        //Act
        administradorServico.Incluir(adm);

        //Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
        Assert.AreEqual(1, adm.Id);
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        //Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        //Act
        administradorServico.Incluir(adm);
        var admBuscado = administradorServico.BuscaPorId(adm.Id);

        //Assert
        Assert.AreEqual(1, admBuscado?.Id);
    }
}