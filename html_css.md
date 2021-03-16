# HTML - CSS

## Nível de "força"
- inline > id > class > tag (1000 > 100 > 10 > 1)
  - **Exemplo:**
    - `p` 1
    - `form p` 1 + 1 = 2 -> maior força, especificidade

---

### `em`
- Unidade de medida dinâmica
- Se baseia em um tamanho de fonte-base

```html
<body>
  <div>texto</div>
</body>
```

```css
body {
  font-size: 14px;
}

div {
  font-size: 2em;
}
```

Segundo este exemplo, o texto dentro de `div` terá tamanho de `2em`. O que define qual o valor de 2, nesse caso, é o valor inicial de `font-size` declarado em `body`, ou seja, `14px`. Então no exemplo acima `div` terá um valor de `font-size` de `28px` (14px x 2em). Basicamente, o que estamos dizendo para o CSS é que cada `em` tem um valor inicial de 14px

```html
<body>
<div> //font-size: 2em x 14px = 28px
        <div> //font-size: 2em x 28px = 56px
              <div> //font-size: 2em x 56px = 112px
                    texto
              </div>
        </div>
      </div>
</body>
```

Quando declaramos a unidade de medida como `em`, cada elemento herda o tamanho de fonte de seu elemento-pai. Isso permite que todos os elementos em que utilizamos essa medida (pode ser fonte, altura, largura, qualquer caso em que se pode aplicar unidades de medida no CSS) aumentem ou diminuam de tamanho de forma proporcional. Legal, né? Porém às vezes não queremos isso!

### `rem`

- *root em*

Podemos especificar um font-size no elemento mais externo do nosso HTML (normalmente na tag `<html>`) e todos os elementos seguirão somente esse valor

```css
html {
  font-size: 14px;
}

div {
  font-size: 2rem;
}
```

```html
<body>
<div> //font-size: 2em x 14px = 28px
        <div> //font-size: 2em x 14px = 28px
              <div> //font-size: 2em x 14px = 28px
                    texto
              </div>
        </div>
      </div>
</body>
```

Quando utilizamos em ou rem sem declarar um tamanho de fonte, o CSS utiliza por padrão a medida de 16px = 1em e 16px = 1rem. Como você já deve ter imaginado, podemos personalizar essa medida inicial de acordo com nosso projeto

```css
html {
  font-size: 25px; //cada em ou rem equivale a 25px
}
```

Ou

```css
html {
  font-size: 25vw; //cada em ou rem equivale a 25% da largura do viewport
}
```
