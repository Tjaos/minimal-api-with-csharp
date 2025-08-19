using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;
using Test.Mocks;

namespace Api.Test.Helpers;

public static class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                //services.AddScoped<IBancoDeDadosServico<Cliente>, ClientesServicoMock>();
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();

            });
        });

        Setup.client = Setup.http.CreateClient();
    }

    public static void ClassCleanup()
    {
        Setup.http.Dispose();
    }
}
