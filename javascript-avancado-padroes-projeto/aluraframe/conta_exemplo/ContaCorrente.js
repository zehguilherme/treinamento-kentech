class ContaCorrente extends Conta {
  atualizar (taxa) {
    this._saldo = this._saldo + taxa
  }
}
