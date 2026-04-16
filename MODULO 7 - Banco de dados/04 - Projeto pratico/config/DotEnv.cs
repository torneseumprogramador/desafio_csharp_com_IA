using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetoPraticoClientes.Config
{
    internal static class DotEnv
    {
        // Carrega um arquivo .env localizado na raiz do projeto (subindo pastas a partir do CWD).
        // Se não existir, retorna um dicionario vazio.
        public static Dictionary<string, string> LoadFromProjectRoot(string fileName = ".env", int maxLevels = 8)
        {
            var path = FindFileUpwards(fileName, maxLevels);
            if (path == null) return new Dictionary<string, string>();

            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    var trimmed = line.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed)) continue;
                    if (trimmed.StartsWith("#")) continue;

                    var idx = trimmed.IndexOf('=');
                    if (idx <= 0) continue;

                    var key = trimmed.Substring(0, idx).Trim();
                    var value = trimmed.Substring(idx + 1).Trim();

                    // Remove aspas simples/dobradas se estiverem presentes.
                    if (value.Length >= 2 &&
                        ((value.StartsWith("\"") && value.EndsWith("\"")) || (value.StartsWith("'") && value.EndsWith("'"))))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        dict[key] = value;
                    }
                }
            }
            catch
            {
                // Se algo der errado ao ler/parsing, nao quebramos a aplicacao.
                return new Dictionary<string, string>();
            }

            return dict;
        }

        private static string? FindFileUpwards(string fileName, int maxLevels)
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            for (var i = 0; i < maxLevels && dir != null; i++)
            {
                var candidate = Path.Combine(dir.FullName, fileName);
                if (File.Exists(candidate)) return candidate;
                dir = dir.Parent;
            }

            return null;
        }
    }
}

