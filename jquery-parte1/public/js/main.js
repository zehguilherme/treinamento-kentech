var campo = $('.campo-digitacao')
var tempoInicial = $('#tempo-digitacao').text()

$(() => {
  atualizaTamanhoDaFrase()
  inicializaContadores()
  inicializaCronometro()
  inicializaMarcadores()
  $('#botao-reiniciar').on('click', reiniciaJogo)
})

function atualizaTamanhoDaFrase () {
  var frase = $('.frase').text()
  var numeroPalavras = frase.split(/\S+/).length - 1
  var tamanhoFrase = $('#tamanho-frase')

  tamanhoFrase.text(numeroPalavras)
}

function inicializaContadores () {
  campo.on('input', () => {
    var conteudo = campo.val()

    var quantidadePalavras = conteudo.split(/\S+/).length - 1
    $('#contador-palavras').text(quantidadePalavras)

    var quantidadeCaracteres = conteudo.length
    $('#contador-caracteres').text(quantidadeCaracteres)
  })
}

function inicializaCronometro () {
  var tempoRestante = $('#tempo-digitacao').text()

  campo.one('focus', () => {
    var cronometroID = setInterval(() => {
      $('#botao-reiniciar').attr('disabled', true)

      tempoRestante--

      $('#tempo-digitacao').text(tempoRestante)

      // Fim do jogo
      if (tempoRestante < 1) {
        clearInterval(cronometroID)
        finalizaJogo()
      }
    }, 1000);
  })
}

function finalizaJogo () {
  campo.attr('disabled', true)
  campo.toggleClass('campo-desativado')
  $('#botao-reiniciar').attr('disabled', false)
  insereResultadoNoPlacar()
}

function inicializaMarcadores () {
  var frase = $('.frase').text()

  campo.on('input', () => {
    var conteudoDigitado = campo.val()
    var digitouCorreto = frase.startsWith(conteudoDigitado) //comparar se a frase começa com aquilo que é digitado pelo usuário

    if (digitouCorreto) {
      campo.addClass('borda-correta')
      campo.removeClass('borda-errada')
    } else {
      campo.addClass('borda-errada')
      campo.removeClass('borda-correta')
    }
  })
}

function reiniciaJogo () {
  campo.attr('disabled', false)
  campo.val('')
  campo.toggleClass('campo-desativado')
  campo.removeClass('borda-errada')
  campo.removeClass('borda-correta')

  $('#contador-palavras').text('0')
  $('#contador-caracteres').text('0')
  $('#tempo-digitacao').text(tempoInicial)

  inicializaCronometro()
}
