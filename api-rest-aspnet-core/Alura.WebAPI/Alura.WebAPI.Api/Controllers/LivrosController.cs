using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public LivrosController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Lista todas as listas de livros e seus livros.",
          Tags = new[] { "Listas" },
          Produces = new[] { "application/json", "application/xml" }
        )]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<LivroApi>))]
        public IActionResult ListaDeLivros()
        {
            var lista = _repo.All.Select(l => l.ToApi()).ToList();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
          Summary = "Recupera o livro identificado por seu {id}.",
          Tags = new[] { "Livros" }, //Agrupar operações que estão distribuídas em vários controladores
          Produces = new[] { "application/json", "application/xml" } //Quais os media-types que operação irá produzir
        )]
        [ProducesResponseType(statusCode: 200, Type = typeof(LivroApi))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
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
          Tags = new[] { "Livros" },
          Produces = new[] { "application/json", "application/xml" }
        )]
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
        [SwaggerOperation(
          Summary = "Altera uma ou mais informações de um livro.",
          Tags = new[] { "Livros" },
          Produces = new[] { "application/json", "application/xml" }
        )]
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
