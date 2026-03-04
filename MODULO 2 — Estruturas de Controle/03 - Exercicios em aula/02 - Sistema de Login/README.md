### Exercício 02 - Sistema de Login com Tentativas

**Cenário real**  
Um sistema interno precisa de uma tela simples de login, onde o usuário tenha um número limitado de tentativas para informar usuário e senha corretos.

### Objetivo

Criar um programa em C# que:

- **Peça** um nome de usuário e uma senha.
- **Compare** com credenciais fixas definidas no código (por exemplo, usuário `"admin"` e senha `"1234"`).
- **Permita** no máximo **3 tentativas** de login usando uma estrutura de repetição.
- **Mostre** mensagens adequadas para sucesso ou falha.

### Comportamento sugerido

1. Definir no código as credenciais válidas, por exemplo:
  - `usuarioCorreto = "admin"`
  - `senhaCorreta = "1234"`
2. Usar um laço (`while` ou `for`) que controle a quantidade de tentativas (ex.: até 3).
3. Dentro do laço:
  - Pedir `"Digite o usuário:"` e ler com `Console.ReadLine()`.
  - Pedir `"Digite a senha:"` e ler com `Console.ReadLine()`.
  - Verificar com `if` se usuário **e** senha conferem.
    - Se estiverem corretos:
      - Exibir `"Login realizado com sucesso!"`.
      - Encerrar o laço (e o programa).
    - Se estiverem incorretos:
      - Exibir `"Usuário ou senha inválidos. Tentativas restantes: X"`.
4. Se o usuário **esgotar** as tentativas sem acertar:
  - Exibir `"Número máximo de tentativas atingido. Acesso bloqueado."`.

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine`.
- Usar uma estrutura de repetição (`while`, `for` ou `do...while`) para controlar as tentativas.
- Usar condicionais `if` / `else` para comparar credenciais.
- Usar operadores lógicos, como `&&`, para verificar usuário **e** senha ao mesmo tempo.
- Utilizar variáveis `string` para usuário/senha e `int` para contar tentativas.

### Desafios extras (opcional)

- Permitir que o usuário **veja quantas tentativas já usou** e quantas restam.
- Diferenciar mensagens de erro:
  - `"Usuário não encontrado"` e `"Senha incorreta"`.
- Usar um operador ternário para montar uma mensagem curta de bloqueio ou sucesso.

