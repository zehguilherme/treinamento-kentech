using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace Alura.ListaLeitura.Api.Controllers
{
  [ApiController]
  [Authorize]
  [ApiVersion("2.0")]
  [ApiExplorerSettings(GroupName = "v2")]
  [Route("api/v{version:apiVersion}/livros")]
  public class Livros2Controller : ControllerBase
  {
    private readonly IRepository<Livro> _repo;

    public Livros2Controller(IRepository<Livro> repository)
    {
      _repo = repository;
    }

    [HttpGet]
    [SwaggerOperation(
      Summary = "Recupera uma coleção paginada de livros.",
      Tags = new[] { "Livros" },
      Produces = new[] { "Livros" }
    )]
    [ProducesResponseType(statusCode: 200, Type = typeof(LivroPaginado))]
    [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
    [ProducesResponseType(statusCode: 404)]
    public IActionResult ListaDeLivros(
      [FromQuery] LivroFiltro filtro,
      [FromQuery] LivroOrdem ordem,
      [FromQuery] LivroPaginacao paginacao)
    {
      var livroPaginado = _repo.All
        .AplicaFiltro(filtro)
        //.AplicaOrdem(ordem)
        .Select(l => l.ToApi())
        .ToLivroPaginado(paginacao);

      return Ok(livroPaginado);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
      Summary = "Recupera o livro identificado por seu {id}.",
      Tags = new[] { "Livros" },
      Produces = new[] { "application/json", "application/xml" } //Quais os media-types que operação irá produzir
    )]
    [ProducesResponseType(statusCode: 200, Type = typeof(Livro))]
    [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
    [ProducesResponseType(statusCode: 404)]
    public IActionResult Recuperar(
      [SwaggerParameter("Id do livro.", Required = true)] int id
    )
    {
      var model = _repo.Find(id);

      if (model == null)
      {
        return NotFound();
      }
      return Ok(model);
    }

    [HttpGet("{id}/capa")]
    [SwaggerOperation(
      Summary = "Recupera a capa do livro identificado por seu {id}.",
      Tags = new[] { "Livros" },
      Produces = new[] { "image/png" }
    )]
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
    [SwaggerOperation(
      Summary = "Registra novo livro na base.",
      Tags = new[] { "Livros" }
    )]
    [ProducesResponseType(statusCode: 201, Type = typeof(LivroApi))]
    [ProducesResponseType(statusCode: 400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
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
      //Código HTTP 400
      return BadRequest(ErrorResponse.FromModelState(ModelState));
    }

    [HttpPut]
    [SwaggerOperation(
      Summary = "Altera uma ou mais informações de um livro.",
      Tags = new[] { "Livros" }
    )]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
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
    [SwaggerOperation(
      Summary = "Remove o livro identificado pelo seu {id}.",
      Tags = new[] { "Livros" }
    )]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
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
