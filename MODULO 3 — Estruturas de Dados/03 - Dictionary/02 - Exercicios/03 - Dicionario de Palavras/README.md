### Exercício 03 - Dicionário de Palavras com Dictionary

**Cenário**  
Você está desenvolvendo um pequeno **dicionário de palavras** em C#. Cada palavra terá um **significado** associado, e tudo será armazenado em um **`Dictionary<string, string>`**, onde:
- A **chave** é a palavra.
- O **valor** é a definição/significado.

### Funcionalidades do sistema

O programa deve apresentar um **menu interativo**, permitindo:

1. **Adicionar/atualizar palavra**
   - Ler a palavra (chave) e sua definição.
   - Se a palavra **não existir** no dicionário, adicioná-la.
   - Se já existir, perguntar se o usuário deseja **atualizar** a definição.

2. **Buscar significado de uma palavra**
   - Ler uma palavra digitada pelo usuário.
   - Usar `ContainsKey` ou `TryGetValue` para verificar se existe.
   - Exibir a definição, se encontrada; caso contrário, mostrar mensagem de que não foi encontrada.

3. **Listar todas as palavras cadastradas**
   - Percorrer o dicionário e exibir todas as palavras e seus significados.
   - Você pode ordenar as palavras por ordem alfabética (opcional).

4. **Remover palavra do dicionário**
   - Ler a palavra e removê-la do dicionário, se existir.

5. **Sair**

### Exemplo de menu

```
Menu:
1 - Adicionar/Atualizar palavra
2 - Buscar significado
3 - Listar todas as palavras
4 - Remover palavra
5 - Sair
Escolha uma opção:
```

### Requisitos Técnicos

- Usar um **`Dictionary<string, string>`** para armazenar as palavras e significados.
- Usar `Add`, indexador (`dict[chave] = valor`), `ContainsKey`, `Remove`, `TryGetValue`.
- Usar laços (`while`/`do...while`) para o menu e `foreach` para percorrer o dicionário.
- Tratar a busca de palavra de forma **case-insensitive** (opcional), por exemplo, usando `ToLower()`.

### Desafios extras (opcional)

- Permitir **importar** algumas palavras iniciais automaticamente (por exemplo, adicionar 3–5 palavras padrão ao iniciar o programa).
- Permitir pesquisar palavras que **comecem com** um certo prefixo (por exemplo, todas que começam com `"pro"`).
- Permitir exportar o dicionário em um formato simples de texto (por exemplo, `"palavra - significado"` por linha).

