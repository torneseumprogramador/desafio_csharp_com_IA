// ================ IF ================
Console.WriteLine("Digite a idade: ");
int idade = int.Parse(Console.ReadLine() ?? "0");

if (idade >= 18)
{
    Console.WriteLine("Você é maior de idade");
}

// ================ IF ELSE ================
Console.WriteLine("Qual sua idade: ");
int idade2 = int.Parse(Console.ReadLine() ?? "0");

if (idade2 >= 18)
{
    Console.WriteLine("Você está com sua entrada permitida");
}
else
{
    Console.WriteLine("Você não está com sua entrada permitida");
}

// ================ IF else if else ================
Console.WriteLine("Fases de uma pessoa\nDigite sua idade: ");
int idade3 = int.Parse(Console.ReadLine() ?? "0");

if (idade3 >= 18)
{
    Console.WriteLine("Você é adulto");
}
else if (idade3 >= 14)
{
    Console.WriteLine("Você é adolescente");
}
else if (idade3 >= 12)
{
    Console.WriteLine("Você é saboooorr adolescente");
}
else
{
    Console.WriteLine("Você é criança");
}


// ================ SWITCH ================
Console.WriteLine("Digite o dia da semana (1-7): ");
int diaDaSemana = int.Parse(Console.ReadLine() ?? "0");

switch (diaDaSemana)
{
    case 1:
        Console.WriteLine("Domingo");
        break;
    case 2:
        Console.WriteLine("Segunda-feira");
        break;
    case 3:
        Console.WriteLine("Terça-feira");
        break;
    case 4:
        Console.WriteLine("Quarta-feira");
        break;
    case 5:
        Console.WriteLine("Quinta-feira");
        break;
    case 6:
        Console.WriteLine("Sexta-feira");
        break;
    case 7:
        Console.WriteLine("Sábado-feira");
        break;
    default:
        Console.WriteLine("Dia inválido");
        break;
}

// ================ Switch moderno C# 8+ ================
Console.WriteLine("Digite o dia da semana (1-7) com switch moderno: ");
int diaDaSemana2 = int.Parse(Console.ReadLine() ?? "0");

string diaDaSemanaString = diaDaSemana2 switch
{
    1 => "Domingo",
    2 => "Segunda-feira",
    3 => "Terça-feira",
    4 => "Quarta-feira",
    5 => "Quinta-feira",
    6 => "Sexta-feira",
    7 => "Sábado",
    _ => "Dia inválido"
};

Console.WriteLine(diaDaSemanaString);

// ================ ternario ================
Console.WriteLine("Digite a idade com ternario: ");
int idade4 = int.Parse(Console.ReadLine() ?? "0");

/*
string resultado = string.Empty;
if (idade4 >= 18)
{
    resultado = "Você é maior de idade";
}
else
{
    resultado = "Você é menor de idade";
}
*/
string resultado = idade4 >= 18 ? "Você é maior de idade" : "Você é menor de idade";
Console.WriteLine(resultado);


// ================ Validando / Setando valores ================
Console.Write("Digite sua idade (idade valida):");
string entrada = Console.ReadLine() ?? "0";

if (int.TryParse(entrada, out int idade5))
{
    if (idade5 >= 18)
    {
        Console.WriteLine($"Você é maior de idade: {idade5} anos");
    }
    else
    {
        Console.WriteLine($"Você é menor de idade: {idade5} anos");
    }
}
else
{
    Console.WriteLine("Valor inválido");
}