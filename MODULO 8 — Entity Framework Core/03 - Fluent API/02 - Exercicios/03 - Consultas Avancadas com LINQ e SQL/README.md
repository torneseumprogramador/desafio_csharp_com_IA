# Exercicio 03 - Consultas Avancadas com LINQ e SQL

## Objetivo
Praticar consultas avancadas no EF Core usando LINQ (method syntax), query syntax (estilo LINQ to SQL) e SQL bruta.

## Cenario
Depois de implementar o CRUD, o time de negocio pediu relatorios com agregacoes e combinacoes entre tabelas.

## Requisitos
- Criar uma pasta `Querys` (ou `Queries`) com classes separadas de consulta.
- Implementar exemplos com:
  1. **LINQ method syntax**
     - `Select` com projecao
     - `GroupBy` com contagem
     - `OrderBy` + `Take`
  2. **Query syntax (estilo LINQ to SQL)**
     - `from`, `join`, `group`, `select`
  3. **SQL bruta**
     - `FromSqlInterpolated`
     - `Database.SqlQuery<T>`
     - opcional: ADO.NET puro com `SqliteConnection`

## Desafios obrigatorios
- Montar um relatorio de emprestimos por status.
- Montar um relatorio com total de livros por autor.
- Exibir dados consolidados com nome do usuario, titulo do livro e status do emprestimo.

## Entregaveis esperados
- Classes de consulta separadas por tipo.
- Chamada das consultas no `Program.cs`.
- Saida no console com titulos para cada tipo de consulta.

## Bonus
- Comparar duas abordagens para o mesmo relatorio:
  - abordagem com EF Core (LINQ)
  - abordagem com SQL bruta
- Explicar em comentarios quando cada abordagem faz mais sentido.
