using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore;

namespace Alura.ListaLeitura.App
{
  class Program
  {
    static void Main(string[] args)
    {
      IWebHost host = new WebHostBuilder()
        .UseKestrel()          //servidor
        .UseStartup<Startup>() //classe de inicialização do servidor
        .Build();

      host.Run();
    }
  }
}
