using System.IO;

namespace Alura.ListaLeitura.App.Html
{
  public class HtmlUtils
  {
    public static string CarregarArquivoHTML(string nomeArquivo)
    {
      var nomeCompletoArquivo = $"Html/{nomeArquivo}.html";

      using (var arquivo = File.OpenText(nomeCompletoArquivo))
      {
        return arquivo.ReadToEnd();
      }
    }
  }
}
