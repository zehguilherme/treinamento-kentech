# JavaScript

### `querySelector`

- Realiza a busca na DOM através de seletores CSS

### `textContent`

- Acessar o texto de um elemento
- `element.textContent`

### `classList`

- Acessar a lista de classes de um elemento
- `element.className`

### `createElement`

- Criar elementos HTML
- `var elemento = document.createElement("div")`

### `innerHTML`

- Define ou obtém a sintaxe HTML ou XML descrevendo os elementos descendentes
- `element.innerHTML`

### Bubbling

Este princípio diz que depois que um evento é disparado no elemento mais distante de uma cadeia aninhada do DOM ele é disparado em seus elementos ancestrais na ordem crescente de aninhamento.

```html
<div class="d1">1  <!-- ancestral mais alto -->
      <div class="d2">2
          <div class="d3">3</div> <!-- descendente mais baixo -->
      </div>
</div>
```
