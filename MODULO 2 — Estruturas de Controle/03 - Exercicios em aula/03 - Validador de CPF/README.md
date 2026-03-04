### Exercício 03 - Validador de CPF com Dígitos Verificadores

**Cenário real**  
Você está desenvolvendo um sistema que precisa validar CPFs informados pelos usuários antes de permitir um cadastro.

### Objetivo

Criar um programa em C# que:

- **Leia** um CPF informado pelo usuário (apenas números).
- **Remova** qualquer caractere de formatação (pontos e traço), se você quiser aceitar `"000.000.000-00"`.
- **Verifique** se tem exatamente 11 dígitos e se **não** são todos iguais (ex.: `"00000000000"`, `"11111111111"` são inválidos).
- **Calcule** os **dois dígitos verificadores** usando laços e operadores aritméticos.
- **Informe** se o CPF é **válido** ou **inválido**.

### Regras para cálculo dos dígitos verificadores (resumo)

Considere apenas os **números**, sem pontos nem traço.

1. **Primeiro dígito verificador**:
  - Pegue os **9 primeiros dígitos** do CPF.
  - Multiplique cada um por um peso que começa em 10 e vai até 2. Exemplo:
    - `d1 * 10`, `d2 * 9`, `d3 * 8`, ..., `d9 * 2`.
  - Some todos os resultados.
  - Calcule o resto da divisão dessa soma por 11 (`soma % 11`).
  - Se o resto for **menor que 2**, o primeiro dígito verificador é `0`.
  - Caso contrário, é `11 - resto`.
2. **Segundo dígito verificador**:
  - Agora considere os **9 primeiros dígitos + o primeiro dígito verificador** (total 10 dígitos).
  - Multiplique cada um por um peso que começa em 11 e vai até 2.
  - Some todos os resultados.
  - Calcule o resto da divisão dessa soma por 11 (`soma % 11`).
  - Se o resto for **menor que 2**, o segundo dígito verificador é `0`.
  - Caso contrário, é `11 - resto`.
3. Compare os dois dígitos calculados com os **dois últimos dígitos** do CPF informado.

### Comportamento sugerido

1. Pedir ao usuário:
  - `"Digite um CPF (apenas números ou com pontuação):"`
2. Tratar a string:
  - Opcionalmente, remover `'.'` e `'-'`.
  - Verificar se o resultado tem 11 caracteres numéricos.
3. Verificar se **todos os dígitos não são iguais** (por exemplo, `"00000000000"`).
4. Calcular os dois dígitos verificadores usando:
  - Laços (`for` ou `while`) para percorrer os dígitos.
  - Operadores aritméticos para multiplicar e somar.
5. Exibir no final:
  - `"CPF válido"` ou `"CPF inválido"`.

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine`.
- Usar `string` e seus métodos (`Replace`, `Substring`, `Length`, `ToCharArray`, etc.) para manipular o CPF.
- Usar pelo menos **um laço** (`for`, `while` ou `foreach`) para percorrer os dígitos.
- Usar condicionais `if` / `else if` / `else` para:
  - Verificar tamanho.
  - Verificar dígitos repetidos.
  - Comparar dígitos calculados com os informados.
- Usar operadores aritméticos (`+`, `*`, `%`) para o cálculo dos dígitos verificadores.

### Desafios extras (opcional)

- Permitir que o usuário digite vários CPFs em sequência até digitar uma palavra de saída (`"sair"`), usando um laço.
- Exibir, além de `"válido"` ou `"inválido"`, uma mensagem dizendo **por que** foi inválido (tamanho incorreto, dígitos iguais, cálculo inválido etc.).
- Encapsular a lógica de validação em um **método** separado que receba uma `string` CPF e devolva `true` ou `false`.

