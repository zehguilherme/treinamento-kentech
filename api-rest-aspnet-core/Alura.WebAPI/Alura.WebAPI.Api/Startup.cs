using Alura.ListaLeitura.Api.Formatters;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alura.WebAPI.Api
{
  //Documenta operações de forma global
  public class AuthResponsesOperationFilter : IOperationFilter
  {
    public void Apply(Operation operation, OperationFilterContext context)
    {
      //Documentação de cada operação tem mais uma resposta 401 com a descrição "Unauthorized".
      operation.Responses.Add("401", new Response { Description = "Unauthorized" });
    }
  }

  //Adiciona informações após a geração da documentação
  //Customiza a documentação para adicionar ou modificar alguma informação
  public class TagDescriptionsDocumentFilter : IDocumentFilter
  {
    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    {
      swaggerDoc.Tags = new[] {
        new Tag { Name = "Livros", Description = "Consulta e mantém os livros." },
        new Tag { Name = "Listas", Description = "Consulta as listas de leitura." }
      };
    }
  }

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<LeituraContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("ListaLeitura"));
      });

      services.AddTransient<IRepository<Livro>, RepositorioBaseEF<Livro>>();

      services.AddMvc(options =>
      {
        options.OutputFormatters.Add(new LivroCsvFormatter());
        options.Filters.Add(typeof(ErrorResponseFilter));
      }).AddXmlSerializerFormatters();

      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.SuppressModelStateInvalidFilter = true;
      });

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
      }).AddJwtBearer("JwtBearer", options =>
      {
        //Realizado quando o token vem na resposta da requisição
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true, //quem cria o token
          ValidateAudience = true, //quem pede o token
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("alura-webapi-authentication-valid")), //chave de autenticação
          ClockSkew = TimeSpan.FromMinutes(5), //tempo para expirar
          ValidIssuer = "Alura.WebApp",
          ValidAudience = "Postman"
        };
      });

      services.AddApiVersioning();

      services.AddSwaggerGen(configuracao =>
      {
        configuracao.SwaggerDoc("v1", new Info
        {
          Title = "Livros API",
          Description = "Documentação da API de livros",
          Version = "1.0"
        });

        configuracao.SwaggerDoc("v2", new Info
        {
          Title = "Livros API",
          Description = "Documentação da API de livros",
          Version = "2.0"
        });

        configuracao.EnableAnnotations();

        //Esquema de autenticação

        /*
        * In: onde o token será enviado
        * apiKey: tipo do mecanismo
        * 
        * Essas opções são usadas para permitir que o Swagger-UI se autentique na API
        * 
        * 
        */

        //Definição do esquema de segurança utilizado
        configuracao.AddSecurityDefinition("Bearer", new ApiKeyScheme
        {
          Name = "Authorization",
          In = "header",
          Type = "apiKey",
          Description = "Autenticação Bearer via JWT"
        });

        //Quais operações usam o esquema definido acima - todas
        //Como a API está com autenticação em todas as suas operações, é aplicado de maneira global
        configuracao.AddSecurityRequirement(
          new Dictionary<string, IEnumerable<string>> {
            {"Bearer", new string[]{ } }
        });

        //Descreve enumerados como strings
        configuracao.DescribeAllEnumsAsStrings();
        configuracao.DescribeStringEnumsInCamelCase();

        configuracao.OperationFilter<AuthResponsesOperationFilter>();

        configuracao.DocumentFilter<TagDescriptionsDocumentFilter>();
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseAuthentication();

      app.UseMvc();

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versão 1.0");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Versão 2.0");
      });
    }
  }
}
