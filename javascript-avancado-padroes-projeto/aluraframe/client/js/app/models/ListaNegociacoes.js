class ListaNegociacoes {
  constructor () {
    this._negociacoes = []
  }

  adicionarNegociacao (negociacao) {
    this._negociacoes.push(negociacao)
  }

  get negociacoes () {
    /**
     * Retorna uma nova lista
     * Cópia da lista this._negociacoes
     */
    return [].concat(this._negociacoes)
  }
}
