class View {
  constructor (elementoHtml) {
    this._elementoHtml = elementoHtml
  }

  template () {
    throw new Error('O método template deve ser implementado')
  }

  atualizar (modelo) {
    this._elementoHtml.innerHTML = this.template(modelo)
  }
}
