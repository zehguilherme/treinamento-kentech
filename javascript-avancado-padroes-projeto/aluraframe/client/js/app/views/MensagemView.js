class MensagemView extends View {
  constructor (elementoHtml) {
    super(elementoHtml)
  }

  template (modelo) {
    return modelo.texto ? `<p class="alert alert-info">${modelo.texto}</p>` : '<p></p>'
  }
}
