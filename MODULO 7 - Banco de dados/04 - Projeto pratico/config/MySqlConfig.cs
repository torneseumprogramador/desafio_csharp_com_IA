using System;
using System.Collections.Generic;

namespace ProjetoPraticoClientes.Config
{
    internal static class MySqlConfig
    {
        // Monta connection string com prioridade:
        // 1) Variaveis de ambiente
        // 2) Arquivo .env (via DotEnv) na raiz do projeto
        public static string GetConnectionString()
        {
            var dotenv = DotEnv.LoadFromProjectRoot();

            static string Get(string key, Dictionary<string, string> dotenv, string fallback)
            {
                // Se a variavel existir mesmo vazia, respeitamos o valor (comportamento do projeto anterior).
                var env = Environment.GetEnvironmentVariable(key);
                if (env != null) return env;

                if (dotenv.TryGetValue(key, out var value)) return value;

                return fallback;
            }

            string host = Get("MYSQL_HOST", dotenv, "localhost");
            string port = Get("MYSQL_PORT", dotenv, "3306");
            string database = Get("MYSQL_DATABASE", dotenv, "projeto_pratico_clientes");
            string user = Get("MYSQL_USER", dotenv, "root");
            string password = Get("MYSQL_PASSWORD", dotenv, "");

            return $"Server={host};Port={port};Database={database};User ID={user};Password={password};";
        }
    }
}

