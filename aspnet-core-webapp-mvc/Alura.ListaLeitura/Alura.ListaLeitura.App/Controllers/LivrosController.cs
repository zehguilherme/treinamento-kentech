using Alura.ListaLeitura.App.Html;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
  public class LivrosController : Controller
  {
    public IEnumerable<Livro> Livros { get; set; }

    public static string CarregarListaDeLivros(IEnumerable<Livro> livros)
    {
      var conteudoArquivo = HtmlUtils.CarregarArquivoHTML("lista");


      return conteudoArquivo.Replace("#NOVO-ITEM#", "");
    }

    public IActionResult ParaLer()
    {
      var repositorio = new LivroRepositorioCSV();

      ViewBag.Livros = repositorio.ParaLer.Livros;

      return View("lista");
    }

    public IActionResult Lendo()
    {
      var repositorio = new LivroRepositorioCSV();

      ViewBag.Livros = repositorio.Lendo.Livros;

      return View("lista");
    }

    public IActionResult Lidos()
    {
      var repositorio = new LivroRepositorioCSV();

      ViewBag.Livros = repositorio.Lidos.Livros;

      return View("lista");
    }

    public string Detalhes(int id)
    {
      var repositorio = new LivroRepositorioCSV();
      var livro = repositorio.Todos.First(l => l.Id == id);

      return livro.Detalhes();
    }

    public string Teste()
    {
      return "A nova funcionalidade foi implementada";
    }
  }
}
