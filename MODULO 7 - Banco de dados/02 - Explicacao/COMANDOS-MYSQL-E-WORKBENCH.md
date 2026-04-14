# Comandos utilizados (MySQL e MySQL Workbench)

Este documento foi organizado para ficar em ordem didatica:

1. Instalacao e configuracao (por sistema operacional)
2. Comandos SQL executados

## 1) Instalacao e configuracao

### 1.1 Verificacoes iniciais (macOS)

#### `brew --version`

- **Objetivo:** verificar se o Homebrew estava instalado.
- **Resultado:** Homebrew encontrado.

#### `uname -m`

- **Objetivo:** identificar a arquitetura da maquina.
- **Resultado:** `x86_64`.

### 1.2 Comandos equivalentes por sistema operacional

#### macOS (Homebrew)

**Instalar/atualizar MySQL**

```bash
brew install mysql
```

**Iniciar e validar servico**

```bash
brew services start mysql
brew services list
mysql --version
```

**Instalar MySQL Workbench**

```bash
brew install --cask mysqlworkbench
```

#### Windows

**Opcao 1: `winget` (recomendado)**

```powershell
winget install Oracle.MySQL
winget install Oracle.MySQLWorkbench
```

**Opcao 2: `choco` (Chocolatey)**

```powershell
choco install mysql -y
choco install mysql.workbench -y
```

**Verificar instalacao**

```powershell
mysql --version
```

**Iniciar servico (se necessario)**

```powershell
net start MySQL80
```

#### Linux (Ubuntu/Debian)

**Instalar MySQL Server + cliente**

```bash
sudo apt update
sudo apt install -y mysql-server mysql-client
```

**Habilitar e iniciar servico**

```bash
sudo systemctl enable mysql
sudo systemctl start mysql
sudo systemctl status mysql
```

**Instalar MySQL Workbench**

```bash
sudo snap install mysql-workbench-community
```

> Alternativa: instalar pacote `.deb` oficial da Oracle.

#### Linux (Fedora/RHEL/CentOS)

**Instalar MySQL Server + cliente**

```bash
sudo dnf install -y mysql-server mysql
```

**Habilitar e iniciar servico**

```bash
sudo systemctl enable mysqld
sudo systemctl start mysqld
sudo systemctl status mysqld
```

### 1.3 Historico de instalacao executado nesta sessao (macOS)

#### `brew install mysql`

- **Objetivo:** instalar (ou atualizar) o MySQL via Homebrew.
- **Resultado:** MySQL atualizado para `9.6.0_2`.

#### `mysql --version`

- **Objetivo:** confirmar cliente MySQL acessivel no sistema.
- **Resultado:** comando executado com sucesso.

#### `brew services list`

- **Objetivo:** verificar status do servico MySQL.
- **Resultado:** `mysql` apareceu como `started`.

#### `brew info mysql | sed -n '1,8p'`

- **Objetivo:** consultar informacoes do pacote MySQL.
- **Resultado:** exibiu dados locais do pacote (houve erro 403 na consulta remota).

#### `brew install --cask mysqlworkbench`

- **Objetivo:** instalar MySQL Workbench via Homebrew Cask.
- **Resultado:** houve conflito de artefatos.

#### `kill 25750`

- **Objetivo:** interromper processo de instalacao que ficou preso.
- **Resultado:** primeira tentativa sem permissao; segunda tentativa concluida.

#### `ls -ld /usr/local/Caskroom/mysqlworkbench /usr/local/Caskroom/mysqlworkbench/8.0.46 /usr/local/Caskroom/mysqlworkbench/8.0.46/MySQLWorkbench.app`

- **Objetivo:** inspecionar residuos da instalacao do cask.
- **Resultado:** caminho principal existia; versao especifica nao.

#### `ls -ld /Applications/MySQLWorkbench.app /usr/local/Caskroom/mysqlworkbench/`*

- **Objetivo:** validar app e conteudo do Caskroom.
- **Resultado:** falhou por wildcard sem correspondencia.

#### `ls -ld /Applications/MySQLWorkbench.app && ls -la "/usr/local/Caskroom/mysqlworkbench"`

- **Objetivo:** confirmar app instalado e metadados do cask.
- **Resultado:** app presente em `/Applications/MySQLWorkbench.app`.

#### `brew list --cask mysqlworkbench`

- **Objetivo:** confirmar registro do cask.
- **Resultado:** cask registrado com metadados.

#### `brew reinstall --cask mysqlworkbench`

- **Objetivo:** tentar reinstalacao para corrigir conflitos.
- **Resultado:** falhou por app ja existente em `/Applications/MySQLWorkbench.app`.

#### `brew install --cask --overwrite mysqlworkbench`

- **Objetivo:** tentativa de sobrescrever app existente.
- **Resultado:** falhou (`--cask` e `--overwrite` incompativeis).

#### `brew install --cask --force mysqlworkbench`

- **Objetivo:** forcar instalacao do cask.
- **Resultado:** execucao interrompida manualmente.

#### `brew services list | rg mysql`

- **Objetivo:** filtrar servico MySQL na listagem.
- **Resultado:** falhou porque `rg` nao estava disponivel naquele contexto do shell.

## 2) Comandos SQL executados

### 2.1 SQL basico (qualquer sistema operacional)

```sql
CREATE DATABASE desafio_csharp_ia;
USE desafio_csharp_ia;
```

### 2.3 Comandos usados no banco `desafio_csharp_ia`

#### Criacao das tabelas (estrutura inicial)

```sql
CREATE TABLE IF NOT EXISTS clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    telefone VARCHAR(20)
);

CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    valor DECIMAL(10,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS pedidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    valor_total DECIMAL(10,2) NOT NULL,
    id_cliente INT NOT NULL,
    CONSTRAINT fk_pedidos_clientes
        FOREIGN KEY (id_cliente)
        REFERENCES clientes(id)
        ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS pedidos_produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_pedido INT NOT NULL,
    id_produto INT NOT NULL,
    quantidade INT NOT NULL DEFAULT 1,
    CONSTRAINT fk_pp_pedido
        FOREIGN KEY (id_pedido)
        REFERENCES pedidos(id)
        ON DELETE CASCADE,
    CONSTRAINT fk_pp_produto
        FOREIGN KEY (id_produto)
        REFERENCES produtos(id)
        ON DELETE CASCADE,
    CONSTRAINT unique_pedido_produto
        UNIQUE (id_pedido, id_produto)
);
```

- **Objetivo:** criar as 4 tabelas do modelo.
- **Detalhe importante:** `UNIQUE (id_pedido, id_produto)` evita repeticao do mesmo produto no mesmo pedido.

#### Validacao de tabelas criadas

```sql
SHOW TABLES;
```

- **Objetivo:** confirmar criacao das tabelas no banco `desafio_csharp_ia`.

#### Carga inicial de dados (5 registros por tabela)

```sql
START TRANSACTION;

INSERT INTO clientes (nome, telefone) VALUES
('Mariana Souza', '(11) 98765-4321'),
('Carlos Henrique Lima', '(21) 99876-1234'),
('Fernanda Alves', '(31) 99123-4567'),
('Rafael Costa', '(41) 98888-7777'),
('Juliana Martins', '(51) 99777-6666');

INSERT INTO produtos (nome, valor) VALUES
('Arroz Tipo 1 5kg', 27.90),
('Feijao Carioca 1kg', 8.50),
('Macarrao Espaguete 500g', 4.80),
('Oleo de Soja 900ml', 7.20),
('Cafe Torrado e Moido 500g', 16.90);

INSERT INTO pedidos (valor_total, id_cliente) VALUES
(55.80, (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1)),
(25.50, (SELECT id FROM clientes WHERE nome='Carlos Henrique Lima' ORDER BY id DESC LIMIT 1)),
(28.80, (SELECT id FROM clientes WHERE nome='Fernanda Alves' ORDER BY id DESC LIMIT 1)),
(16.90, (SELECT id FROM clientes WHERE nome='Rafael Costa' ORDER BY id DESC LIMIT 1)),
(43.70, (SELECT id FROM clientes WHERE nome='Juliana Martins' ORDER BY id DESC LIMIT 1));

INSERT INTO pedidos_produtos (id_pedido, id_produto, quantidade) VALUES
((SELECT p.id FROM pedidos p JOIN clientes c ON c.id = p.id_cliente WHERE c.nome='Mariana Souza' ORDER BY p.id DESC LIMIT 1), (SELECT id FROM produtos WHERE nome='Arroz Tipo 1 5kg' ORDER BY id DESC LIMIT 1), 2),
((SELECT p.id FROM pedidos p JOIN clientes c ON c.id = p.id_cliente WHERE c.nome='Carlos Henrique Lima' ORDER BY p.id DESC LIMIT 1), (SELECT id FROM produtos WHERE nome='Feijao Carioca 1kg' ORDER BY id DESC LIMIT 1), 3),
((SELECT p.id FROM pedidos p JOIN clientes c ON c.id = p.id_cliente WHERE c.nome='Fernanda Alves' ORDER BY p.id DESC LIMIT 1), (SELECT id FROM produtos WHERE nome='Macarrao Espaguete 500g' ORDER BY id DESC LIMIT 1), 6),
((SELECT p.id FROM pedidos p JOIN clientes c ON c.id = p.id_cliente WHERE c.nome='Rafael Costa' ORDER BY p.id DESC LIMIT 1), (SELECT id FROM produtos WHERE nome='Cafe Torrado e Moido 500g' ORDER BY id DESC LIMIT 1), 1),
((SELECT p.id FROM pedidos p JOIN clientes c ON c.id = p.id_cliente WHERE c.nome='Juliana Martins' ORDER BY p.id DESC LIMIT 1), (SELECT id FROM produtos WHERE nome='Arroz Tipo 1 5kg' ORDER BY id DESC LIMIT 1), 1);

COMMIT;
```

- **Objetivo:** popular o banco com dados de exemplo.
- **Boas praticas:** uso de transacao (`START TRANSACTION` + `COMMIT`).

#### Conferencia de totais por tabela

```sql
SELECT 'clientes' AS tabela, COUNT(*) AS total FROM clientes
UNION ALL
SELECT 'produtos', COUNT(*) FROM produtos
UNION ALL
SELECT 'pedidos', COUNT(*) FROM pedidos
UNION ALL
SELECT 'pedidos_produtos', COUNT(*) FROM pedidos_produtos;
```

- **Objetivo:** validar quantidade de linhas em cada tabela.

#### Relatorio de pedidos da Mariana

```sql
SELECT
    c.nome AS cliente,
    p.id AS pedido_id,
    pr.nome AS produto,
    pp.quantidade,
    pr.valor AS valor_unitario,
    (pp.quantidade * pr.valor) AS subtotal_item,
    p.valor_total AS valor_total_pedido
FROM clientes c
JOIN pedidos p ON p.id_cliente = c.id
JOIN pedidos_produtos pp ON pp.id_pedido = p.id
JOIN produtos pr ON pr.id = pp.id_produto
WHERE c.nome LIKE 'Mariana%'
ORDER BY p.id;
```

- **Objetivo:** listar itens dos pedidos da Mariana com subtotal.

#### Comparacao do total calculado x total registrado

```sql
SELECT
    p.id AS pedido_id,
    SUM(pp.quantidade * pr.valor) AS total_calculado,
    p.valor_total AS total_registrado
FROM clientes c
JOIN pedidos p ON p.id_cliente = c.id
JOIN pedidos_produtos pp ON pp.id_pedido = p.id
JOIN produtos pr ON pr.id = pp.id_produto
WHERE c.nome LIKE 'Mariana%'
GROUP BY p.id, p.valor_total
ORDER BY p.id;
```

- **Objetivo:** garantir coerencia entre total dos itens e `valor_total` em `pedidos`.

#### Insercao de mais pedidos para a Mariana

```sql
START TRANSACTION;

INSERT INTO pedidos (valor_total, id_cliente) VALUES
(33.70, (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1)),
(43.50, (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1)),
(29.70, (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1));

INSERT INTO pedidos_produtos (id_pedido, id_produto, quantidade) VALUES
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 2), (SELECT id FROM produtos WHERE nome='Feijao Carioca 1kg' ORDER BY id DESC LIMIT 1), 2),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 2), (SELECT id FROM produtos WHERE nome='Oleo de Soja 900ml' ORDER BY id DESC LIMIT 1), 2),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 1), (SELECT id FROM produtos WHERE nome='Cafe Torrado e Moido 500g' ORDER BY id DESC LIMIT 1), 1),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 1), (SELECT id FROM produtos WHERE nome='Arroz Tipo 1 5kg' ORDER BY id DESC LIMIT 1), 1),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 0), (SELECT id FROM produtos WHERE nome='Macarrao Espaguete 500g' ORDER BY id DESC LIMIT 1), 3),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 0), (SELECT id FROM produtos WHERE nome='Feijao Carioca 1kg' ORDER BY id DESC LIMIT 1), 1),
((SELECT id FROM pedidos WHERE id_cliente = (SELECT id FROM clientes WHERE nome='Mariana Souza' ORDER BY id DESC LIMIT 1) ORDER BY id DESC LIMIT 1 OFFSET 0), (SELECT id FROM produtos WHERE nome='Cafe Torrado e Moido 500g' ORDER BY id DESC LIMIT 1), 1);

COMMIT;
```

- **Objetivo:** adicionar novos pedidos para a cliente Mariana.

#### Relatorio de quantidade de pedidos por pessoa

```sql
SELECT
    c.id,
    c.nome,
    COUNT(p.id) AS quantidade_pedidos
FROM clientes c
LEFT JOIN pedidos p ON p.id_cliente = c.id
GROUP BY c.id, c.nome
ORDER BY quantidade_pedidos DESC, c.nome ASC;
```

- **Objetivo:** mostrar todos os clientes, inclusive sem pedido (`LEFT JOIN`).

