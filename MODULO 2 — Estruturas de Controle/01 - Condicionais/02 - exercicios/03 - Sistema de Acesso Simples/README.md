### Exercício 03 - Sistema de Acesso Simples

**Cenário real**  
Uma aplicação interna de uma empresa precisa liberar ou negar acesso a determinadas áreas do sistema de acordo com o **perfil do usuário**.

### Objetivo
Criar um programa em C# que:
- **Peça** ao usuário que informe seu tipo de perfil.
- **Valide** o valor informado.
- **Use** um `switch` (simples ou moderno) para decidir o nível de acesso.
- **Mostre** mensagens diferentes conforme o perfil.

### Perfis sugeridos
Peça ao usuário para digitar um número representando o perfil:
- `1` - Administrador
- `2` - Gerente
- `3` - Funcionário
- `4` - Visitante

### Regras de acesso sugeridas
- **Administrador**: acesso total ao sistema.
- **Gerente**: acesso a relatórios e cadastros principais.
- **Funcionário**: acesso básico às funcionalidades do dia a dia.
- **Visitante**: acesso somente à visualização de informações públicas.
- Qualquer outro valor: `"Perfil inválido"`.

### Requisitos técnicos
- Ler a entrada como `string` e tentar converter para `int` usando `int.TryParse`.
  - Se a conversão falhar, mostrar `"Perfil inválido"` e encerrar.
- Usar um `switch` (como no exemplo do dia da semana que você estudou) para tratar os perfis.
- Em cada `case`, exibir uma mensagem clara, por exemplo:
  - `"Bem-vindo, Administrador. Você tem acesso total."`
- Usar `default` para tratar perfis inválidos.

### Versão com switch expression (opcional)
- Opcionalmente, crie uma versão usando o **switch moderno** (expression) atribuindo uma string de mensagem a uma variável:
  - Ex.: `string mensagem = perfil switch { ... };`
- Depois, faça `Console.WriteLine(mensagem);`

### Desafios extras (opcional)
- Perguntar também se o usuário está **ativo** no sistema (`S` ou `N`).
  - Se não estiver ativo, negar o acesso, mesmo que o perfil seja válido.
  - Para isso, combine:
    - `switch` para o perfil
    - `if`/`else` ou operador ternário para o status ativo/inativo.

