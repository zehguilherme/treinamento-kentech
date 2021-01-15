$('#botao-placar').click(mostrarPlacar)
$('#botao-sync').click(sincronizarPlacarComServidor)

function insereResultadoNoPlacar () {
  var corpoTabela = $('.placar').find('tbody')
  var usuario = $('#usuarios').val()
  var numeroPalavras = $('#contador-palavras').text()

  var linha = adicionarNovaLinhaNoPlacar(usuario, numeroPalavras)
  linha.find('.botao-remover').on('click', removerUsuarioDoPlacar)

  corpoTabela.append(linha)

  $('.placar').slideDown(800)
}

function scrollPlacar () {
  var posicaoPlacar = $('.placar').offset().top

  $('body').animate({
    scrollTop: `${posicaoPlacar} px`
  }, 800)
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
  var linha = $(this).parent().parent()
  linha.fadeOut(800)

  setTimeout(() => {
    linha.remove()
  }, 800);
}

function mostrarPlacar () {
  $('.placar').stop().slideToggle(800)
}

function sincronizarPlacarComServidor () {
  var placar = []
  var linhas = $('tbody>tr')

  linhas.each(function () {
    var usuario = $(this).find('td:nth-child(1)').text()
    var quantidadePalavras = $(this).find('td:nth-child(2)').text()

    var score = {
      usuario: usuario,
      pontos: quantidadePalavras
    }

    placar.push(score)
  })

  var dados = {
    placar: placar
  }

  $.post('http://localhost:3000/placar', dados, () => {
    $('.tooltip').tooltipster('open').tooltipster('content', 'Sucesso ao sincronizar')
  })
    .fail(() => {
      $('.tooltip').tooltipster('open').tooltipster('content', 'Falha ao sincronizar')
    })
    .always(() => {
      setTimeout(() => {
        $('.tooltip').tooltipster('close')
      }, 1200);
    })
}

function atualizaPlacarComOsDadosDoServidor () {
  $.get('http://localhost:3000/placar', (data) => {
    $(data).each(function () {
      var linha = adicionarNovaLinhaNoPlacar(this.usuario, this.pontos)

      linha.find('.botao-remover').click(removerUsuarioDoPlacar)

      $('tbody').append(linha)
    })
  })
}
