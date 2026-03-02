### Exercício 02 - Classificação de Temperatura

**Cenário real**  
Um aplicativo de previsão do tempo precisa classificar a temperatura do dia em categorias para exibir mensagens mais amigáveis ao usuário.

### Objetivo
Criar um programa em C# que:
- **Leia** a temperatura atual em graus Celsius digitada pelo usuário.
- **Valide** a entrada usando `int.TryParse` ou `double.TryParse`.
- **Classifique** a temperatura em faixas usando condicionais.
- **Mostre** uma mensagem adequada para cada faixa.

### Regras de classificação sugeridas
- **Abaixo de 0°C**: `"Muito frio"`
- **De 0°C até 15°C**: `"Frio"`
- **De 16°C até 25°C**: `"Agradável"`
- **De 26°C até 35°C**: `"Quente"`
- **Acima de 35°C**: `"Muito quente"`

Use uma estrutura de:
- `if`
- `else if`
- `else`

### Requisitos técnicos
- Usar `Console.WriteLine` e `Console.ReadLine` para entrada e saída.
- Validar a entrada com `double.TryParse`:
  - Se não for um número válido, exibir: `"Temperatura inválida"` e **não** continuar o cálculo.
- Exibir no final algo como:
  - `"Temperatura informada: X°C"`
  - `"Classificação: Agradável"`

### Versão com operador ternário (opcional)
- Depois de classificar, use um operador **ternário** para montar uma mensagem curta:
  - Ex.: `string alerta = temperatura > 35 ? "Atenção: beba bastante água!" : "Tenha um bom dia!";`

### Desafios extras (opcional)
- Pedir também o **nome da cidade** e incluir na mensagem final.
- Permitir ao usuário informar a **sensação térmica** e exibir a maior entre temperatura e sensação usando um operador ternário.

