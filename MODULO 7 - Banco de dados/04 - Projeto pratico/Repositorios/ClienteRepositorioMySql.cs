using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProjetoPraticoClientes.Config;
using ProjetoPraticoClientes.Models;

namespace ProjetoPraticoClientes.Repositorios
{
    public class ClienteRepositorioMySql : IClienteRepositorio
    {
        private readonly string _connectionString;

        public ClienteRepositorioMySql()
        {
            // A configuracao (env vars + .env) fica centralizada na pasta `config`.
            _connectionString = MySqlConfig.GetConnectionString();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            // Lista que sera preenchida a partir dos dados do banco.
            var clientes = new List<Cliente>();

            // O bloco using garante que a conexao sera fechada/discartada automaticamente.
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    // SQL de leitura:
                    // - Nao ha concatenacao de entrada do usuario -> evita SQL Injection.
                    string sql = "SELECT id, nome, email, telefone FROM clientes ORDER BY id;";

                    // MySqlCommand representa o comando SQL executado.
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        // MySqlDataReader lera o resultado linha a linha.
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Mapeia cada coluna do resultset para a entidade Cliente.
                                var cliente = new Cliente
                                {
                                    Id = reader.GetInt32(0), // id
                                    Nome = reader.GetString(1), // nome
                                    Email = reader.GetString(2), // email
                                    Telefone = reader.GetString(3) // telefone
                                };

                                clientes.Add(cliente);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Para o menu continuar rodando, retornamos lista vazia.
                    // (No proximo passo, voce pode evoluir o tratamento de erros.)
                    Console.WriteLine("Erro ao obter clientes no MySQL:");
                    Console.WriteLine(ex.Message);
                    return new List<Cliente>();
                }
            }

            return clientes;
        }

        public Cliente? ObterPorId(int id)
        {
            // Busca um unico cliente pelo ID.
            // Aqui usamos parametro (@id) para evitar SQL Injection.
            string sql = "SELECT id, nome, email, telefone FROM clientes WHERE id = @id;";

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            // Se existir linha, mapeamos; se nao existir, retornamos null.
                            if (reader.Read())
                            {
                                return new Cliente
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Telefone = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Por enquanto, em caso de erro, retornamos null para o menu tratar como "nao encontrado".
                    Console.WriteLine("Erro ao obter cliente por id no MySQL:");
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return null;
        }

        public IEnumerable<Cliente> BuscarPorNome(string termo)
        {
            // Busca por parte do nome (equivalente a: nome.Contains(termo) no codigo em memoria/json).
            // Usamos parametro (@termo) ao inves de concatenar string para evitar SQL Injection.
            var clientes = new List<Cliente>();

            // Mantem o comportamento do repositorio em memoria/json:
            // - termo null/espaco vira string vazia
            // - com string vazia, o LIKE '% %' acaba retornando todos (mesmo comportamento do Contains).
            termo = termo?.Trim() ?? string.Empty;
            string like = $"%{termo}%";

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    string sql = @"
                        SELECT id, nome, email, telefone
                        FROM clientes
                        WHERE nome LIKE @termo
                        ORDER BY nome;";
               

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@termo", like);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(new Cliente
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Telefone = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Mantemos consistente com os outros metodos: em caso de erro, nao quebrar o menu.
                    Console.WriteLine("Erro ao buscar clientes por nome no MySQL:");
                    Console.WriteLine(ex.Message);
                    return new List<Cliente>();
                }
            }

            return clientes;
        }

        public Cliente Cadastrar(string nome, string email, string telefone)
        {
            // Insere um novo cliente no banco.
            // Usamos parametros para evitar SQL Injection.
            // Para recuperar o ID gerado automaticamente, utilizamos ExecuteScalar.

            string sql = @"
                INSERT INTO clientes (nome, email, telefone)
                VALUES (@nome, @email, @telefone);
                SELECT LAST_INSERT_ID();";

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@telefone", telefone);

                        // comando.ExecuteNonQuery();
                        // // Retorna o AUTO_INCREMENT gerado para o INSERT acima.
                        // long idInserido = comando.LastInsertedId;

                        // ExecuteScalar retorna o id recém inserido
                        object result = comando.ExecuteScalar();
                        long idInserido = (result != null && result != DBNull.Value) ? Convert.ToInt64(result) : 0;

                        return new Cliente
                        {
                            Id = checked((int)idInserido),
                            Nome = nome,
                            Email = email,
                            Telefone = telefone
                        };
                    }
                }
                catch (MySqlException ex)
                {
                    // Se der erro de banco/SQL, nao vamos "fingir" que cadastrou.
                    Console.WriteLine("Erro ao cadastrar cliente no MySQL:");
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public bool Atualizar(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            // Atualiza dados de um cliente pelo ID.
            // Usamos parametros (@id, @nome, ...) para evitar SQL Injection.
            string sql = @"
                UPDATE clientes
                SET nome = @nome,
                    email = @email,
                    telefone = @telefone
                WHERE id = @id;";

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@nome", novoNome);
                        comando.Parameters.AddWithValue("@email", novoEmail);
                        comando.Parameters.AddWithValue("@telefone", novoTelefone);

                        // ExecuteNonQuery retorna quantidade de linhas afetadas.
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        // Se afetou 1 linha, o cliente existia.
                        return linhasAfetadas > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao atualizar cliente no MySQL:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Remover(int id)
        {
            // Remove o cliente pelo ID.
            // Tambem aqui usamos parametros para evitar SQL Injection.
            string sql = "DELETE FROM clientes WHERE id = @id;";

            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();

                        // Se afetou 1 linha, o cliente existia e foi removido.
                        return linhasAfetadas > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao remover cliente no MySQL:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}

