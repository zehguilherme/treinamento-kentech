# ASP NET Core

## MVC (Model View Controller)

### Model
- Classes de negócio
- Elas modelam a aplicação

### View
- Classes e arquivos para tratar da parte que o usuário visualiza

### Controller
- A lógica de controle/atendimento das requisições

---

## Estágios de execução do framework

- O Framework é que trata as respostas das requisições

### Execute Result
- Etapa que ocorre depois da execução da **action**

---

## Roteamento padrão

`.../Controller/Action/ID`
  - 3º segmento é opcional

---

## Segurança

### Usando Cookies

<div align="center">
  <img src="https://user-images.githubusercontent.com/36301054/110509567-ff593c80-80e0-11eb-8949-9ee2878a91c7.png" alt="Segurança com token">
</div>

<br/>

1. Login é realizado através do preenchimento de um formulário
2. Aplicação valida o login -> Gera um `Session ID` -> Coloca as informações do usuário numa base de dados em memória
3. Envia na resposta um HTTP 200 OK contendo o valor do `Session ID` no **cookie**
4. A partir disso, todas as próximas **requisições** que o cliente fizer terão esse `Session ID` dentro do cookie
  - Será sempre verificado se esse `Session ID` está na base de dados, dando a autorização ou não
  - Essas próximas requisições ficam agrupadas, criando uma sensação de que existe um estado (aplicação conhece quem está fazendo todas as requisições seguintes)
    - Há acoplamento entre elas (**não é o ideal**)

### Usando Token

<div align="center">
  <img src="https://user-images.githubusercontent.com/36301054/110663275-09dd0a00-81a5-11eb-8fbb-ae70233c748a.png" alt="Segurança comm token">
</div>

<br/>

- Não usa `Session ID`
- Não usa `cookies`
- Quando um cliente envia uma requisição para a aplicação, esta "embrulha" todas as informações necessárias para uma próxima requisição no `token` e envia na resposta para o cliente
- Futuras requisições precisam enviar de volta esse `token`
  - Não há nenhuma informação que necessite ser consultada pela aplicação (`Session ID` usado anteriormente). Ela apenas irá "desembrulhar" o `token` e verificar as informações (para dar permissão de acesso) que já estão ali dentro
- Token pode ser enviado no **corpo da requisição** ou **cabeçalho da requisição**
- As requisições não possuem acoplamento com a aplicação

#### JWT (JSON Web Tokens)

- Um dos padrões usados nas configurações de token
- String criptografada usando base 64
- [Site para mais informações](https://jwt.io/)

<br/>

<div align="center">
  <img src="https://user-images.githubusercontent.com/36301054/110821712-1af24d80-826f-11eb-86fd-1462c4444943.png" alt="Resumo do curso de ASP.NET Core">
</div>

---

## Versionamento de uma API

  ### Funcionalidades

  <div align="center">
    <img src="https://user-images.githubusercontent.com/36301054/111191261-a41ec280-8596-11eb-9dd9-d1cd09467e26.png" alt="Resumo do curso de ASP.NET Core - parte 2">
  </div>

  <br/>

  <div align="center">
    <img src="https://user-images.githubusercontent.com/36301054/111213582-a8a3a500-85af-11eb-89fd-834859752495.png" alt="Aprendizado do curso parte 3">
  </div>
  
---

## Lidando com coleções grandes

<div align="center">
    <img src="https://user-images.githubusercontent.com/36301054/111315015-bbb28580-8640-11eb-84fd-d5eb8d09afce.png" alt="Lidando com coleções grandes">
</div>
