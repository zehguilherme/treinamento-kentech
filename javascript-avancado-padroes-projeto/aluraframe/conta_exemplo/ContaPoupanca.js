class ContaPoupanca extends Conta {
  atualizar (taxa) {
    this._saldo = this._saldo + (taxa * 2)
  }
}
