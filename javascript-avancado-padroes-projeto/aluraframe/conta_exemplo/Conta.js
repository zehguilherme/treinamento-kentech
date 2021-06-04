class Conta {
  constructor (saldo) {
    this._saldo = saldo
  }

  get saldo () {
    return this._saldo
  }

  atualizar (taxa) {
    throw new Error('Você deve sobrescrever o método')
  }
}
