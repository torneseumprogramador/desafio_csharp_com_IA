# Exercicio - API de Clientes com SQLite (Minimal API)

## Contexto

Com base no conteudo da aula de criacao de projeto Web com ASP.NET Core e Minimal API, seu desafio e construir uma API REST simples persistindo dados em banco SQLite.

## Objetivo

Criar uma API de **Clientes** com operacoes de CRUD, usando:

- `ASP.NET Core Minimal API`
- `Entity Framework Core`
- `SQLite`

## Requisitos tecnicos

1. Criar um novo projeto Web API em Minimal API.
2. Adicionar os pacotes necessarios para usar EF Core com SQLite.
3. Criar o modelo `Cliente` com, no minimo, os campos:
   - `Id` (int)
   - `Nome` (string)
   - `Email` (string)
   - `Telefone` (string)
4. Criar o `DbContext` (ex.: `AppDbContext`) com `DbSet<Cliente>`.
5. Configurar a conexao com SQLite no projeto.
6. Criar e aplicar migration para gerar o banco.
7. Implementar os endpoints abaixo:
   - `GET /clientes` - listar todos
   - `GET /clientes/{id}` - buscar por id
   - `POST /clientes` - cadastrar
   - `PUT /clientes/{id}` - atualizar
   - `DELETE /clientes/{id}` - remover
8. Retornar status HTTP adequados:
   - `200 OK` para consultas e atualizacao
   - `201 Created` para cadastro
   - `204 No Content` para exclusao
   - `404 Not Found` quando o cliente nao existir
9. Habilitar documentacao da API com Swagger.

## Regras de negocio

- Nao permitir cadastro de cliente com `Nome` vazio.
- Nao permitir cadastro de cliente com `Email` vazio.
- No `POST`, o `Id` deve ser gerado pela aplicacao/banco.
- No `PUT`, atualizar apenas se o cliente existir.

## Entregaveis

- Codigo fonte do projeto.
- Arquivo de banco SQLite gerado pela aplicacao.
- Endpoints funcionando e testados (Swagger ou arquivo `.http`).

## Desafio extra (opcional)

1. Adicionar campo `DataCadastro` no cliente.
2. Criar endpoint `GET /clientes/busca?nome=...` para filtrar por nome.
3. Impedir cadastro de emails duplicados.

## Criterios de avaliacao

- Projeto compila e executa sem erros.
- Endpoints seguem o padrao REST proposto.
- Persistencia no SQLite funcionando corretamente.
- Organizacao e clareza do codigo.
