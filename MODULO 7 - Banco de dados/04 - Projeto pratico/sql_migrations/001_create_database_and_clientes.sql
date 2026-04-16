-- Migration 001
-- Objetivo: criar o banco de dados e a tabela `clientes` conforme a entidade `Cliente`.
-- Entidade (Cliente.cs):
-- - Id (int)
-- - Nome (string)
-- - Email (string)
-- - Telefone (string)

CREATE DATABASE IF NOT EXISTS projeto_pratico_clientes
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE projeto_pratico_clientes;

CREATE TABLE IF NOT EXISTS clientes
(
  id INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(100) NOT NULL,
  email VARCHAR(255) NOT NULL,
  telefone VARCHAR(30) NOT NULL,
  PRIMARY KEY (id)
);

-- Observacao didatica: em um projeto real, voce poderia adicionar UNIQUE(email)
-- para evitar cadastros duplicados de email.

