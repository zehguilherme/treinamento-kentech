/**
 * "_prop" -> convenção de que as propriedades com "underline" só podem ser acessadas pelos próprios métodos da classe (propriedades privadas)
*/

/**
 * ... -> spread operator
 * - permite passar um array como parâmetro de um construtor, classe, função, etc
 * - indica que o array será desmembrado em vários itens (1º parâmetro do array é o 1º parâmetro da função, por exemplo)
*/

class NegociacaoController {
  constructor () {
    let $ = document.querySelector.bind(document)

    this._inputData = $('#data')
    this._inputQuantidade = $('#quantidade')
    this._inputValor = $('#valor')

    this._listaNegociacoes = new ListaNegociacoes()

    this._negociacoesView = new NegociacoesView($('#negociacoesView'))
    this._negociacoesView.atualizar(this._listaNegociacoes)

    this._mensagem = new Mensagem()
    this._mensagemView = new MensagemView($('#mensagemView'))
    this._mensagemView.atualizar(this._mensagem)
  }

  adiciona (event) {
    event.preventDefault()

    this._listaNegociacoes.adicionarNegociacao(this._criarNegociacao())
    this._negociacoesView.atualizar(this._listaNegociacoes)

    this._mensagem.texto = 'Negociação adicionada com sucesso!'
    this._mensagemView.atualizar(this._mensagem)

    this._limparFormulario()
  }

  _criarNegociacao () {
    return new Negociacao(
      DateHelper.converterTextoEmData(this._inputData.value),
      this._inputQuantidade.value,
      this._inputValor.value
    )
  }

  _limparFormulario () {
    this._inputData.value = ""
    this._inputQuantidade.value = 1
    this._inputValor.value = 0.0

    this._inputData.focus()
  }
}
