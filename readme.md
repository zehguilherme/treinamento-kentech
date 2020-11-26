<details>
  <summary>HTML</summary>

### `<fieldset>`
- Configuração de um ou mais campos referentes a um assunto específico em um formulário
- Um assunto e seus vários campos

### `<legend>`
- Título de um `<fieldset>`
- Título de um grupo de campos no formulário
</details>

<details>
  <summary>HTML - CSS</summary>

### Nível de "força"
- inline > id > class > tag (1000 > 100 > 10 > 1)
  - **Exemplo:**
    - `p` 1
    - `form p` 1 + 1 = 2 -> maior força, especificidade
</details>

<details>
  <summary>CSS</summary>

### `position`
- `static`
  - Posição natural/padrão do elemento

- `relative`
  - **Exemplo:**
    - Depois de tal elemento carregado, deseja-se mudar o ponto inicial dele a partir do ponto inicial
    - 'Olha' a partir do ponto inicial, mas tem uma nova posição que é relativa a aquela posição inicial
    - Elemento está deslocado, mas o ponto inicial continua onde deveria estar

- `absolute`
  - Nos possibilita mudar a posição inicial em que determinado elemento se encontra
  - Posicioná-lo em qualquer lugar da página
  - **Exemplo:**
    - Ser absoluto em relação a página toda;
    - em relação ao cabeçalho, etc

### `display`
  - `inline-block`
    - Um elemento com essa propriedade possui o tamanho do seu conteúdo, mas regulável
    - O tamanho pode ser ajustado, tanto na largura, quanto na altura

### `box-sizing`
  - `border-box`
    - As propriedades de `width` e de `height` incluem o tamanho padding size e a propriedade `border`, mas não incluem a propriedade `margin`.
    - O espaçamento lateral passa a ficar dentro do percentual

### Pseudo-classes
  - `active`: quando um elemento está sendo ativado pelo usuário

</details>
