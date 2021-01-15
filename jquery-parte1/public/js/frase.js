$('#botao-frase').click(buscarFraseAleatoria)
$('#botao-frase-id').click(buscarUmaFraseEspecifica)

function buscarFraseAleatoria () {
  $('#spinner').toggle()

  $.get('http://localhost:3000/frases', trocarFraseAleatoriamente)
    .fail(() => {
      $('#erro').toggle()
      setTimeout(() => {
        $('#erro').toggle()
      }, 2000);
    })
    .always(() => $('#spinner').toggle())
}

function trocarFraseAleatoriamente (data) {
  var frase = $('.frase')
  var numeroAleatorio = Math.floor(Math.random() * data.length)

  frase.text(data[numeroAleatorio].texto)

  atualizaTamanhoDaFrase()
  atualizarTempoInicial(data[numeroAleatorio].tempo)
}

function buscarUmaFraseEspecifica () {
  $('#spinner').toggle()

  var fraseID = $('#frase-id').val()
  var dados = { id: fraseID }

  $.get('http://localhost:3000/frases/', dados, trocarParaFraseEspecifica)
    .fail(() => {
      $('#erro').toggle()
      setTimeout(() => {
        $('#erro').toggle()
      }, 2000);
    })
    .always(() => $('#spinner').toggle())
}

function trocarParaFraseEspecifica (data) {
  var frase = $('.frase')

  frase.text(data.texto)

  atualizaTamanhoDaFrase()
  atualizarTempoInicial(data.tempo)
}
