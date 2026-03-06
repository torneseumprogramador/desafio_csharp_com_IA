### Exercício - Sistema de Alunos com Lista e Notas

**Cenário**  
Você está desenvolvendo um pequeno sistema em C# para gerenciar alunos e suas notas. Cada aluno pode ter até **3 notas** (por exemplo: Prova 1, Prova 2 e Prova 3), e os dados dos alunos serão armazenados em uma **List**. As notas de cada aluno devem ser armazenadas em um **array fixo de 3 elementos** (`double[]`).

O programa deve apresentar um **menu interativo** para o usuário, permitindo:

1. **Cadastrar um novo aluno**  
    - O usuário informa o nome do aluno.
    - O usuário informa as **3 notas** (com validação).
    - O aluno e suas notas são armazenados na lista.

2. **Exibir relatório de alunos**  
    - Listar todos os alunos cadastrados.
    - Para cada aluno, mostrar:
        - Nome
        - Notas (ex: Nota 1: 8.0 | Nota 2: 7.5 | Nota 3: 9.0)
        - **Média das notas** (ex.: Média: 8.17)

3. **Sair** do sistema.

---

#### Exemplo de menu

```
Menu:
1 - Cadastrar novo aluno
2 - Exibir relatório de alunos
3 - Sair
Escolha uma opção:
```

---

### Requisitos Técnicos

- Usar uma **classe `Aluno`** com ao menos:
    - Propriedade para o nome.
    - Array de 3 notas (`double[]`).
- Usar uma **List<Aluno>** para armazenar os alunos.
- Usar **array fixo de 3 elementos** para as notas de cada aluno.
- Validar todas as entradas numéricas com `double.TryParse`.
- Utilizar interpolação de string (`$"..."`) para exibir as mensagens.
- Utilizar laços de repetição para percorrer a lista e os arrays de notas.
- Calcular corretamente a média das 3 notas do aluno.

---

### Desafio extra (opcional)

- Permitir consultar um aluno pelo nome e mostrar suas notas e média individual.
- Permitir editar notas de um aluno já cadastrado.
- No relatório, mostrar quais alunos tiveram média maior ou igual a 7 ("Aprovado") ou menor que 7 ("Reprovado").

---