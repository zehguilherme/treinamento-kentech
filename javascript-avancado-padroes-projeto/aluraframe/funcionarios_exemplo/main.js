let funcionarios = [
    {
        "nome": "Douglas",
        "endereco": "Rua da esquina, 123",
        "salario": "4500"
    },
    {
        "nome": "Felipe",
        "endereco": "Rua da virada, 456",
        "salario": "5000"
    },
    {
        "nome": "Silvio",
        "endereco": "Rua da aresta, 789",
        "salario": "6000"
    }
];

let funcionariosEmHtml = funcionarios.map(funcionario => `
                <tr>
                    <td>${funcionario.nome}</td>
                    <td>${funcionario.endereco}</td>
                    <td>${funcionario.salario}</td>
                </tr>
            `);

let htmlConcatenado = funcionariosEmHtml.join('')

let tabela = document.querySelector('tbody')
tabela.innerHTML = htmlConcatenado