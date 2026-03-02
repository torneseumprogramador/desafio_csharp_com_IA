### Exercício 01 - Verificação de Desconto em Compras

**Cenário real**  
Uma loja quer calcular o valor final de uma compra aplicando descontos diferentes de acordo com o valor total da compra.

### Objetivo

Criar um programa em C# que:

- **Leia** do usuário o valor total de uma compra.
- **Valide** a entrada usando `int.TryParse` ou `double.TryParse`.
- **Aplique** regras de desconto usando estruturas condicionais.
- **Mostre** o valor final com o desconto aplicado.

### Regras de negócio sugeridas

- **Compras até R$ 99,99**: sem desconto.
- **De R$ 100,00 até R$ 499,99**: 5% de desconto.
- **De R$ 500,00 até R$ 999,99**: 10% de desconto.
- **Acima de R$ 1000,00**: 15% de desconto.

Você pode ajustar os valores se quiser, mas mantenha a lógica de faixas usando:

- `if`
- `else if`
- `else`

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine` para interagir com o usuário.
- Validar a entrada com `double.TryParse`:
  - Se a conversão **falhar**, mostrar uma mensagem como: `"Valor inválido"` e encerrar o programa.
- Usar pelo menos **uma cadeia de `if / else if / else`**.
- Opcional: usar operador **ternário** para montar uma mensagem final, por exemplo:
  - `"Você ganhou desconto"` ou `"Você não ganhou desconto"`.

### Exemplo (sugestão)

- Entrada: `Valor da compra: 550`
- Saída:
  - `Valor original: R$ 550,00`
  - `Desconto aplicado: 10%`
  - `Valor final: R$ 495,00`

### Desafios extras (opcional)

- Permitir que o usuário informe **forma de pagamento** (`1 - Dinheiro`, `2 - Cartão`, `3 - PIX`) e usar um `switch` para:
  - Mostrar uma mensagem diferente para cada forma de pagamento.
  - Ex.: `"Você escolheu pagar no cartão"`.

