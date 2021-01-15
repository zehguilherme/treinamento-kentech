using Alura.ListaLeitura.App.Html;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
  public class CadastroController
  {
    public string Incluir(Livro livro)
    {
      var repositorio = new LivroRepositorioCSV();

      repositorio.Incluir(livro);

      return "Livro adicionado com sucesso";
    }

    public IActionResult ExibirFormulario()
    {
      // ViewResult: representa resultados de actions que retornam HTML
      var html = new ViewResult { ViewName = "formulario" };

      return html;
    }
  }
}
