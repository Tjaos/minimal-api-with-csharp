using MinimalApi;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });

await hostBuilder.Build().RunAsync();