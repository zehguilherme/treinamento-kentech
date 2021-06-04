/**
 * static -> métodos que são invocados diretamente na classe, não sendo necessário instanciá-la
 * métodos que pertencem a definição da classe
 */

class DateHelper {
  constructor () {
    throw new Error('Esta classe não pode ser instanciada')
  }

  static converterTextoEmData (texto) {
    if (!/^\d{4}-\d{2}-\d{2}$/.test(texto)) {
      throw new Error('Deve estar no formato aaaa-mm-dd')
    }

    return new Date(
      ...texto.split('-').map((item, indice) => item - indice % 2)
    )
  }

  static converterDataEmTexto (data) {
    return `${data.getDate()}/${data.getMonth() + 1}/${data.getFullYear()}`
  }
}
