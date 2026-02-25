
// declaracao de variáveis estatica
string nome = "Danilo";
int idade = 20;

// declaracao de variáveis dinamica
var nome2 = "Danilo";
var idade2 = 20;

//idade += "- Danilo"; -- Ilegal porque o C# é fortemente tipado
string resultado = Convert.ToString(idade) + " - " + nome; // fortemente tipado, precisa fazer a conversao de tipo de dado para outro tipo de dado
string resultado2 = idade2.ToString() + " - " + nome2; // fortemente tipado, precisa fazer a conversao de tipo de dado para outro tipo de dado
int resultado3 = int.Parse("2") + idade; // fortemente tipado, precisa fazer a conversao de tipo de dado para outro tipo de dado

Console.WriteLine(resultado); // saida de dados
Console.WriteLine(resultado2);
Console.WriteLine(resultado3);

Console.WriteLine("Digite seu nome: ");
nome = Console.ReadLine(); // entrada de dados
Console.WriteLine("Seu nome é: " + nome);

// Boas práticas de nomenclatura
/*
PascallCase = para nome de classes
  string UsuarioComDadosAtonimos = "usuario_com_dados_atonomos"
camelCase = para nome de variaveis
  string usuarioComDadosAtonimos = "usuario_com_dados_atonomos"
snake_case = para nome de alguns arquivos
  string usuario_com_dados_atonomos = "usuario_com_dados_atonomos"
*/



/*
statica ou dinamica

fortemente tipada ou fracamente tipada

node = fracamente tipada - nao fazer um processo de conversao de tipo de dado para outro tipo de dado
c# = fortemente tipada - fazer um processo de conversao de tipo de dado para outro tipo de dado
*/





