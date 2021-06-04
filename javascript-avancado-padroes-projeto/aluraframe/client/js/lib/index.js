const campos = [
  document.querySelector('#data'),
  document.querySelector('#quantidade'),
  document.querySelector('#valor'),
]

const tbody = document.querySelector('table tbody')

document.querySelector('.form').addEventListener('submit', function (event) {
  event.preventDefault() //não submeter o formulário como padrão

  const trTabela = document.createElement('tr')

  campos.forEach(function (campo) {
    const tdTabela = document.createElement('td')
    tdTabela.textContent = campo.value

    trTabela.appendChild(tdTabela)
  })

  const tdVolume = document.createElement('td')
  tdVolume.textContent = campos[1].value * campos[2] //quantidade * valor

  trTabela.appendChild(tdVolume)

  tbody.appendChild(trTabela)

  // Resetar campos
  campos[0].value = ''
  campos[1].value = 1
  campos[2].value = 0

  campos[0].focus()
})
