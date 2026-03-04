Console.WriteLine("Digite um CPF (apenas números ou com pontuação):");
string cpf = Console.ReadLine() ?? "";

// Remove qualquer caractere que não seja número
cpf = System.Text.RegularExpressions.Regex.Replace(cpf, "[^0-9]", "");

// Verifica se tem exatamente 11 dígitos
if (cpf.Length != 11)
{
    Console.WriteLine("CPF inválido");
    return;
}

// Verifica se todos os dígitos são iguais (ex.: 00000000000, 11111111111)
bool todosIguais = true;
for (int i = 1; i < cpf.Length; i++)
{
    if (cpf[i] != cpf[0])
    {
        todosIguais = false;
        break;
    }
}

if (todosIguais)
{
    Console.WriteLine("CPF inválido");
    return;
}

// Calcula o primeiro dígito verificador
int soma1 = 0;
for (int i = 0; i < 9; i++)
{
    int digito = cpf[i] - '0';
    soma1 += digito * (10 - i);
}

int resto1 = soma1 % 11;
int digito1 = (resto1 < 2) ? 0 : 11 - resto1;

// Calcula o segundo dígito verificador
int soma2 = 0;
for (int i = 0; i < 9; i++)
{
    int digito = cpf[i] - '0';
    soma2 += digito * (11 - i);
}
soma2 += digito1 * 2;

int resto2 = soma2 % 11;
int digito2 = (resto2 < 2) ? 0 : 11 - resto2;

// Compara os dígitos calculados com os dois últimos dígitos do CPF informado
bool cpfValido = (cpf[9] - '0') == digito1 && (cpf[10] - '0') == digito2;

Console.WriteLine(cpfValido ? "CPF válido" : "CPF inválido");
