### Exercício 03 - Cadastro de Alunos em Matriz

**Cenário real**  
Você está montando um pequeno sistema para registrar alunos e suas notas em uma tabela (matriz) para depois exibir um boletim simples.

### Objetivo

Criar um programa em C# que:

- **Cadastre** o nome e a nota de alguns alunos usando uma **matriz**.
- **Calcule** a **média** de cada aluno.
- **Mostre** um "boletim" no console com nome e nota/média.

Você pode usar:

- Uma matriz de `string` para nome e nota,  
  **ou**
- Duas estruturas: um `string[]` para nomes e um `double[]` para notas.

### Comportamento sugerido

1. Perguntar: `"Quantos alunos serão cadastrados?"`
2. Validar com `int.TryParse`.
3. Criar uma matriz, por exemplo:  
   `string[,] alunos = new string[quantidade, 2];`  
   - Coluna 0: nome do aluno  
   - Coluna 1: nota do aluno (em string, ou usar outro array de `double`).
4. Usar um laço `for` para:
   - pedir o nome do aluno;
   - pedir a nota (validando com `double.TryParse`);
   - armazenar nas posições corretas.
5. Após o cadastro, percorrer novamente a estrutura para:
   - somar as notas;
   - calcular a média geral da turma (se desejar);
   - exibir cada aluno no formato:  
     `"Nome: João - Nota: 8,5"`.

### Requisitos técnicos

- Usar **matriz** (`[,]`) OU combinação de arrays (`string[]` e `double[]`).
- Usar `for` ou `foreach` para percorrer as estruturas.
- Validar a entrada de notas com `double.TryParse`.
- Usar interpolação de string (`$"..."`) para montar as mensagens.

### Desafios extras (opcional)

- Permitir o cadastro de **duas notas por aluno** (por exemplo, Prova 1 e Prova 2) e calcular a média de cada um.
- Mostrar quais alunos ficaram **acima** e **abaixo** da média da turma.
- Permitir que o usuário pesquise um aluno pelo nome e veja a(s) nota(s) dele.

