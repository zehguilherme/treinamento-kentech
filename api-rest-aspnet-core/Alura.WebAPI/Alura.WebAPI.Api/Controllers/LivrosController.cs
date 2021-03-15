using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Alura.ListaLeitura.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class LivrosController : ControllerBase
  {
    private readonly IRepository<Livro> _repo;

    public LivrosController(IRepository<Livro> repository)
    {
      _repo = repository;
    }

    [HttpGet]
    public IActionResult ListaDeLivros()
    {
      var lista = _repo.All.Select(l => l.ToApi()).ToList();

      return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult Recuperar(int id)
    {
      var model = _repo.Find(id);

      if (model == null)
      {
        return NotFound();
      }
      return Ok(model.ToApi());
    }

    [HttpGet("{id}/capa")]
    public IActionResult ImagemCapa(int id)
    {
      byte[] img = _repo.All
          .Where(l => l.Id == id)
          .Select(l => l.ImagemCapa)
          .FirstOrDefault();
      if (img != null)
      {
        return File(img, "image/png");
      }
      return File("~/images/capas/capa-vazia.png", "image/png");
    }

    [HttpPost]
    public IActionResult Incluir([FromForm] LivroUpload model)
    {
      if (ModelState.IsValid)
      {
        var livro = model.ToLivro();

        _repo.Incluir(livro);

        //URL que aponta para o novo objeto Livro criado
        var uri = Url.Action("Recuperar", new { id = livro.Id });

        return Created(uri, livro); //Código HTTP 201
      }
      return BadRequest(); //Código HTTP 400
    }

    [HttpPut]
    public IActionResult Alterar([FromForm] LivroUpload model)
    {
      if (ModelState.IsValid)
      {
        var livro = model.ToLivro();
        if (model.Capa == null)
        {
          livro.ImagemCapa = _repo.All
              .Where(l => l.Id == livro.Id)
              .Select(l => l.ImagemCapa)
              .FirstOrDefault();
        }
        _repo.Alterar(livro);
        return Ok(); //Código HTTP 200
      }
      return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
      var model = _repo.Find(id);
      if (model == null)
      {
        return NotFound();
      }
      _repo.Excluir(model);
      return NoContent(); //Código HTTP 204 - não existe mais nenhum conteúdo apontando para esse identificador
    }
  }
}
