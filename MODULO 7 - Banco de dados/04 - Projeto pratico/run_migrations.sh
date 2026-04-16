#!/usr/bin/env bash
set -euo pipefail

PROJECT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MIGRATIONS_DIR="${PROJECT_DIR}/sql_migrations"

MYSQL_USER="${MYSQL_USER:-root}"
MYSQL_PASSWORD="${MYSQL_PASSWORD:-}"
MYSQL_HOST="${MYSQL_HOST:-localhost}"
MYSQL_PORT="${MYSQL_PORT:-3306}"

if [[ ! -d "$MIGRATIONS_DIR" ]]; then
  echo "Nao encontrei a pasta de migrations: $MIGRATIONS_DIR"
  exit 1
fi

# Monta opcoes do mysql conforme se a senha foi informada.
MYSQL_OPTS=(-u "$MYSQL_USER" -h "$MYSQL_HOST" -P "$MYSQL_PORT")
if [[ -n "$MYSQL_PASSWORD" ]]; then
  MYSQL_OPTS+=(-p"$MYSQL_PASSWORD")
fi

shopt -s nullglob
files=("${MIGRATIONS_DIR}"/*.sql)
if (( ${#files[@]} == 0 )); then
  echo "Nenhuma migration .sql encontrada em: ${MIGRATIONS_DIR}"
  exit 1
fi

# Ordena os caminhos sem quebrar por causa de espacos.
while IFS= read -r file; do
  echo "==> Rodando migração: $(basename "$file")"
  mysql "${MYSQL_OPTS[@]}" < "$file"
done < <(printf '%s\n' "${files[@]}" | sort)

echo "Migrations finalizadas com sucesso."

