using System;
using MySql.Data.MySqlClient;

namespace ConectandoComCSharpAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // String de conexao para SQL Server.
            // Ajuste os valores conforme seu ambiente:
            // - Server: endereco do servidor MySQL (ex.: localhost)
            // - Database: banco que voce quer acessar
            // - User Id / Password: credenciais de acesso no MySQL
            string connectionString =
                "Server=localhost;Port=3306;Database=desafio_csharp_ia;User ID=root;Password=;";

            // O bloco using garante que o objeto MySqlConnection sera descartado
            // automaticamente ao final do escopo, mesmo em caso de erro.
            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine("Tentando abrir conexao com o banco...");
                    conexao.Open();

                    // MySqlCommand representa um comando SQL que sera executado no MySQL.
                    // Aqui usamos um SELECT simples para contar quantos registros existem na tabela clientes.
                    string sql = "SELECT COUNT(*) FROM clientes;";

                    // O comando precisa de duas informacoes principais:
                    // 1) texto SQL
                    // 2) conexao aberta que ele vai utilizar para executar o SQL
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        // ExecuteScalar() e ideal quando o SQL retorna apenas 1 valor (1 linha, 1 coluna).
                        object? resultado = comando.ExecuteScalar();

                        // Convert.ToInt32 transforma o retorno para inteiro, tratando nulos de forma segura.
                        int totalClientes = Convert.ToInt32(resultado);

                        Console.WriteLine($"Total de clientes encontrado: {totalClientes}");
                    }

                    // Exemplo com MySqlDataReader:
                    // neste caso, buscamos multiplas linhas da tabela clientes.
                    string sqlLeitura = "SELECT id, nome, telefone FROM clientes LIMIT 5;";

                    using (MySqlCommand comandoLeitura = new MySqlCommand(sqlLeitura, conexao))
                    {
                        using (MySqlDataReader reader = comandoLeitura.ExecuteReader())
                        {
                            Console.WriteLine("\nClientes lidos com MySqlDataReader:");

                            // Read() avanca linha por linha no resultado da consulta.
                            while (reader.Read())
                            {
                                // GetInt32/GetString leem colunas tipadas pelo indice da coluna.
                                // IsDBNull evita erro quando a coluna pode ser nula.
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                string telefone = reader.IsDBNull(2) ? "sem telefone" : reader.GetString(2);

                                Console.WriteLine($"Id: {id} | Nome: {nome} | Telefone: {telefone}");
                                Console.WriteLine("--------------------------------");
                            }
                        }
                    }

                    // Exemplo com ExecuteNonQuery():
                    // usado para comandos que NAO retornam linhas (INSERT, UPDATE, DELETE).
                    // Neste exemplo, fazemos um UPDATE simples e recebemos quantas linhas foram afetadas.
                    string sqlAtualizacao = "UPDATE clientes SET telefone = @telefone WHERE id = @id;";

                    using (MySqlCommand comandoAtualizacao = new MySqlCommand(sqlAtualizacao, conexao))
                    {
                        // Parametros evitam SQL Injection e tratam tipos corretamente.
                        comandoAtualizacao.Parameters.AddWithValue("@telefone", "(11) 90000-0000");
                        comandoAtualizacao.Parameters.AddWithValue("@id", 1);

                        // ExecuteNonQuery() retorna um inteiro com o total de linhas afetadas.
                        int linhasAfetadas = comandoAtualizacao.ExecuteNonQuery();

                        Console.WriteLine($"\nExecuteNonQuery concluido. Linhas afetadas: {linhasAfetadas}");
                    }

                    // Exemplo didatico: comparacao entre SQL vulneravel e SQL seguro.
                    ExemploSqlInjection(conexao);

                }
                catch (MySqlException ex)
                {
                    // MySqlException tambem captura erros de comando SQL,
                    // como tabela inexistente, sintaxe invalida ou permissao negada.
                    Console.WriteLine("Erro ao executar MySqlCommand:");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Exception captura erros gerais que nao sejam especificamente SQL.
                    Console.WriteLine("Erro inesperado:");
                    Console.WriteLine(ex.Message);
                }
            }

            // Fora do using, a conexao ja foi encerrada e liberada automaticamente.
            Console.WriteLine("Processo finalizado. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }

        private static void ExemploSqlInjection(MySqlConnection conexao)
        {
            Console.WriteLine("\n===== Exemplo SQL Injection =====");

            // Simula uma entrada maliciosa do usuario.
            string entradaUsuario = "' OR '1'='1";

            // EXEMPLO VULNERAVEL:
            // Aqui a entrada do usuario é concatenada direto no SQL.
            // Isso permite que a pessoa altere a logica da consulta.
            string sqlVulneravel =
                "SELECT COUNT(*) FROM clientes WHERE nome = '" + entradaUsuario + "';";

            Console.WriteLine("SQL vulnerável (nao execute em producao!):");
            Console.WriteLine(sqlVulneravel);

            // Executando SQL vulnerável:
            using (MySqlCommand comandoVulneravel = new MySqlCommand(sqlVulneravel, conexao))
            {
                int totalVulneravel = Convert.ToInt32(comandoVulneravel.ExecuteScalar());
                Console.WriteLine($"Resultado do SQL vulnerável (com possível injection): {totalVulneravel}");
            }

            // EXEMPLO SEGURO:
            // Aqui usamos parametro (@nome), impedindo que a entrada altere o SQL.
            string sqlSeguro = "SELECT COUNT(*) FROM clientes WHERE nome = @nome;";
            using (MySqlCommand comandoSeguro = new MySqlCommand(sqlSeguro, conexao))
            {
                comandoSeguro.Parameters.AddWithValue("@nome", entradaUsuario);
                int totalSeguro = Convert.ToInt32(comandoSeguro.ExecuteScalar());
                Console.WriteLine($"Resultado do SQL seguro (com parâmetro): {totalSeguro}");
            }
        }
    }
}
