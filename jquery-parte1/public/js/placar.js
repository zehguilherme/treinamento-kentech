function insereResultadoNoPlacar () {
  var corpoTabela = $('.placar').find('tbody')
  var usuario = 'José Guilherme'
  var numeroPalavras = $('#contador-palavras').text()

  var linha = adicionarNovaLinhaNoPlacar(usuario, numeroPalavras)
  linha.find('.botao-remover').on('click', removerUsuarioDoPlacar)

  corpoTabela.append(linha)
}

function adicionarNovaLinhaNoPlacar (usuario, numeroPalavras) {
  var linha = $('<tr>')
  var colunaUsuario = $('<td>').text(usuario)
  var colunaNumeroPalavras = $('<td>').text(numeroPalavras)
  var colunaBotaoRemover = $('<td>')

  var link = $('<a>').addClass('botao-remover').attr('href', '#')
  var icone = $('<i>').addClass('small').addClass('material-icons').text('delete')

  link.append(icone)
  colunaBotaoRemover.append(link)
  linha.append(colunaUsuario, colunaNumeroPalavras, colunaBotaoRemover)

  return linha
}

function removerUsuarioDoPlacar (event) {
  event.preventDefault()
  $(this).parent().parent().remove()
}
