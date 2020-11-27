<div align="center">
  <img src="https://cursos.alura.com.br/assets/images/logos/logo-alura.svg" alt="Logo da Alura">
</div>

<br>

<details>
  <summary>HTML</summary>

### `<fieldset>`
- Configuração de um ou mais campos referentes a um assunto específico em um formulário
- Um assunto e seus vários campos

### `<legend>`
- Título de um `<fieldset>`
- Título de um grupo de campos no formulário

### `<div>`
- Divisão apenas visual

### `<section>`
- Divisão em que há um conteúdo complexo (semânticamente faz um mesmo sentido como um todo)
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

### Cálculos
  - `calc(operações desejadas)`

---

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

### `clear`
  - Limpa os elementos que estavam sendo afetados pelo `float`
  - Elementos que não deveriam ser afetados (abaixo dele)

### `background`
  - `linear-gradient(graus - inclinação, cor, cor, cor, etc)`: transição de uma cor para outra
  - `radial-gradient(cor, cor, cor, etc)`: transição de uma cor para outra (radial - redondo)

---

### Pseudo-classes
  - `:active`: quando um elemento está sendo ativado pelo usuário
  - `:nth-child(numero do elemento)`: selecionar um elemento específico de um lista, por exemplo

---

### Pseudo-elementos
- **Elementos criados no CSS que não existem no HTML**

  - `:first-letter`: primeira letra de um texto
  - `:first-line`: primeira linha
  - `:before`: Cria um espaço antes do elemento onde o CSS pode ser usado
  - `:after`: Cria um espaço depois do elemento onde o CSS pode ser usado

---

### Seletores avançados
- `>`
  - **Selecionar filhos diretos do elemento pai**
  - **Exemplo:**
    ```
    main > p {
      background: red;
    }
    ```

- `+`
  - **Selecionar 1º irmão de determinado elemento**
  - Todo parágrafo que vem após uma imagem
  - **Exemplo:**
    ```
    img + p {
      background: blue;
    }
    ```

- `~`
  - **Selecionar todos os irmãos de determinado elemento**
  - Todos os parágrafos que vem após uma imagem
  - **Exemplo:**
    ```
    img ~ p {
      background: blue;
    }
    ```

- `:not()`
  - **Selecionar todos os elementos, exceto algum**
  - Todos os parágrafos que não fazem parte da missão, não possuem o `id` `missao` => `#missao`
  - **Exemplo:**
    ```
    principal p:not(#missao) {
      background: orange;
    }
    ```

</details>
