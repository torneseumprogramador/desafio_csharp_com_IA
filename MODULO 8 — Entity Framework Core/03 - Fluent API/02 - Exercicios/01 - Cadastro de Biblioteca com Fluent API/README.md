# Exercicio 01 - Cadastro de Biblioteca com Fluent API

## Objetivo
Criar um projeto de console com Entity Framework Core usando SQLite para modelar um sistema de biblioteca, configurando todas as entidades com Fluent API.

## Cenario
Voce foi contratado para iniciar o modulo de catalogo de uma biblioteca digital. O sistema precisa armazenar autores, livros e usuarios, com regras de validacao e relacionamentos no banco.

## Requisitos
- Criar as entidades `Autor`, `Livro` e `Usuario`.
- Configurar o `DbContext` com `DbSet` para cada entidade.
- Criar classes de configuracao usando `IEntityTypeConfiguration<T>` (uma por entidade).
- Aplicar as configuracoes no contexto com `ApplyConfigurationsFromAssembly`.
- Definir no Fluent API:
  - nome de tabelas e colunas;
  - campos obrigatorios;
  - tamanho maximo de string;
  - indice unico para ISBN e Email;
  - relacionamento entre `Livro` e `Autor` com chave estrangeira.

## Entregaveis esperados
- Estrutura de pastas organizada (`Models`, `Data`, `Data/Configurations`).
- Banco SQLite criado automaticamente na primeira execucao.
- Insercao de dados iniciais para teste.

## Bonus
- Configurar comportamento de delete com `DeleteBehavior.Restrict`.
- Adicionar pelo menos um campo opcional e um obrigatorio em cada entidade.
