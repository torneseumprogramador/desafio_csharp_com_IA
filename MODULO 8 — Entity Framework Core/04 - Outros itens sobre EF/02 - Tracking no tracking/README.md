# Tracking vs No Tracking (EF Core + SQLite)

Este projeto demonstra, na prática, a diferença entre **tracking** e **no tracking** no Entity Framework Core usando **SQLite**.

## Como executar

```bash
dotnet run --project "02 - Traking no traking.csproj"
```

O código cria um banco local `tracking-demo.db` e imprime no console o resultado de cada cenário.

## O que é *Tracking*?

Por padrão, quando você consulta entidades no EF Core, o `DbContext` **rastrea** essas instâncias — ou seja, coloca todas no **Change Tracker**.

Isso significa que o EF:
- Mantém as entidades em memória e acompanha seu estado;
- Detecta alterações nas propriedades utilizando snapshots/internamente;
- Ao chamar `SaveChanges()`, gera comandos `UPDATE/INSERT/DELETE` automaticamente para todas as entidades alteradas.

### Vantagens do Tracking

- **Atualização automática:** basta alterar os objetos e depois chamar `SaveChanges()`;
- **Relacionamentos:** útil para cenários onde você carrega/edita vários objetos conectados (ex: gráficos de entidades);
- **Consistência:** dentro do mesmo contexto, a mesma entidade (mesmo `Id`) não é duplicada, facilitando lógica e validação;
- **Menos código:** não precisa anexar manualmente entidades salvas recentemente ou alteradas.

### Quando usar Tracking?

- Telas/fluxos de **edição** (CRUD) onde você pode editar e esperar persistência com `SaveChanges()`;
- Rotinas em que precisa de **controle de estado** (`Added`, `Modified`, `Deleted`) e navegações.

**Pergunta frequente:**  
Utilizo o tracking quando quero garantir que todas as instâncias consultadas, inseridas ou atualizadas reflitam suas alterações dentro do mesmo contexto, ou seja, no mesmo bloco de consulta/execução. Assim, consigo ver as entidades sendo atualizadas em tempo real, inclusive antes de persistir no banco com `SaveChanges()`.

---

## O que é *No Tracking* (`AsNoTracking`)

Quando você usa `AsNoTracking()`, o EF Core **NÃO** coloca as entidades retornadas no Change Tracker.

Principais consequências:
- Você pode alterar o objeto em memória, mas o EF Core **não percebe** essas mudanças;
- `SaveChanges()` **NÃO** persiste essas alterações, a não ser que você anexe/atualize manualmente depois.

### Vantagens do No Tracking

- **Performance de leitura**: o EF faz menos esforço (não gera snapshots nem monitora mudanças);
- **Menor consumo de memória:** essencial para grandes listas ou consultas pesadas;
- **Menos risco de “vazar estado”** em situações onde o contexto tem vida longa.

### Quando usar No Tracking?

- Consultas **somente leitura** (relatórios, dashboards, listagens);
- APIs que retornam DTOs simples, sem pretensão de gravar de volta no banco;
- Processamentos em lote onde não é necessário rastrear entidades.

**Pergunta frequente:**  
No *no tracking*, é ideal para cenários onde quero apenas ler diretamente o dado do banco, por exemplo quando há concorrência e existem transações pendentes de commit. O resultado reflete apenas o que está persistido no banco, sem influências de alterações locais em entidades ainda não salvas pelo contexto.

---

## Como salvar algo vindo de No Tracking

Se você consultou usando `AsNoTracking()` e depois quiser persistir mudanças, faça assim:
- Use `Update(entity)` (marca como `Modified`) ou `Attach(entity)` e defina propriedades específicas como modificadas;
- Depois, `SaveChanges()` irá persistir;
- **Dica:** antes disso, se o contexto já estiver rastreando uma instância com mesmo `Id`, execute `context.ChangeTracker.Clear()` para evitar erro:

> “The instance of entity type 'X' cannot be tracked because another instance with the same key value is already being tracked…”

Esse erro ocorre quando tenta anexar uma segunda instância do mesmo `Id` em um contexto que já rastreia outra.

---

## Dicas práticas

- **Regra de ouro:**
  - Vai **editar e salvar**? Use tracking (padrão).
  - É **somente leitura**? Use `AsNoTracking()`.
- **NoTracking global (opcional):** Para apps muito orientados a leitura, pode configurar no `DbContext`:
  - `ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;`
  - E usar `AsTracking()` só em fluxos que exigem edição/persistência.
- **Cuidado com `Update*`:** Ele tende a marcar **todas** as propriedades como modificadas. Prefira `Attach` e marque apenas o que mudou, para updates mais seguros e eficientes.

---

## Referência no código

Veja o `Program.cs`, que demonstra:
- Consulta com **tracking** (padrão) e persistência automática;
- Consulta com **no tracking** e ausência de persistência;
- Como persistir após no tracking, anexando a entidade ao contexto.

---

## Resumindo

- Use **tracking** se quiser editar entidades e garantir que todas as instâncias alteradas, inseridas ou removidas sejam mantidas e sincronizadas pelo contexto. Isso é útil em blocos de código onde várias operações dependem do mesmo estado das instâncias, por exemplo, em transações de "edição em lote", ou para garantir que as alterações feitas na mesma unidade de trabalho sejam visíveis entre si até o commit.
- Use **no tracking** quando o foco for somente leitura, performance e/ou evitar problemas de concorrência (ler apenas o que já foi persistido por outros, ignorando mudanças locais ainda não salvas). Assim, sua consulta refletirá sempre o banco de dados real naquele momento, sem se preocupar com o "estado não confirmado" do contexto.

Em resumo:  
- **Tracking** = edição, gráficos complexos, consistência dentro do contexto.  
- **No tracking** = consultas de leitura, performance, leitura concorrente segura, menos uso de memória.

Se precisar dos dois comportamentos na mesma aplicação, misture conforme a necessidade de cada consulta!