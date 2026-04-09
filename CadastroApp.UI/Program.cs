using CadastroApp.Application.Interfaces;
using CadastroApp.Application.Services;
using CadastroApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroApp.UI;

internal static class Program
{
    public static ServiceProvider? ServiceProvider { get; private set; }
    private static readonly string ConnectionString = @"Server=PC\SQLEXPRESS;Database=CadastroApp;Integrated Security=True;TrustServerCertificate=True;";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        ConfigurarServicos();

        var frmPrincipal = ServiceProvider!.GetRequiredService<frmPrincipal>();
        System.Windows.Forms.Application.Run(frmPrincipal);
    }

    static void ConfigurarServicos()
    {
        var services = new ServiceCollection();
        services.AddScoped<IProdutoRepository>(_ => new ProdutoRepository(ConnectionString));
        services.AddScoped<ProdutoService>();

        services.AddTransient<frmPrincipal>();
        services.AddTransient<frmCadastroProduto>();

        ServiceProvider = services.BuildServiceProvider();
    }
}