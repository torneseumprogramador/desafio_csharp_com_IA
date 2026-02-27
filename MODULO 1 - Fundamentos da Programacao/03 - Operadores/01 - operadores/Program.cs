/*
========= Operadores Aritméticos =========

| Operador | Nome           | Exemplo |
| -------- | -------------- | ------- |
| `+`      | Soma           | `a + b` |
| `-`      | Subtração      | `a - b` |
| `*`      | Multiplicação  | `a * b` |
| `/`      | Divisão        | `a / b` |
| `%`      | Módulo (resto) | `a % b` |

*/

int a = 10;
int b = 3;

Console.WriteLine(a + b); // 13
Console.WriteLine(a - b); // 7
Console.WriteLine(a * b); // 30
Console.WriteLine(a / b); // 3
Console.WriteLine(a % b); // 1


/*
========= Operadores Relacionais =========
| Operador | Significado    |
| -------- | -------------- |
| `==`     | Igual          |
| `!=`     | Diferente      |
| `>`      | Maior          |
| `<`      | Menor          |
| `>=`     | Maior ou igual |
| `<=`     | Menor ou igual |

*/

int idade = 18;

Console.WriteLine(idade > 18); // false
Console.WriteLine(idade < 18);  // false
Console.WriteLine(idade == 18); // true
Console.WriteLine(idade != 18); // false
Console.WriteLine(idade >= 18); // true
Console.WriteLine(idade <= 18); // true



/*
========= Operadores Lógicos =========
| Operador | Nome      | Exemplo  |
| -------- | --------- | -------- |
| `&&`     | AND (E)   | `a && b` |
| `||`     | OR (OU)   | `a || b` |
| `!`      | NOT (NÃO) | `!a`     |
*/

bool maiorDeIdade = true;
bool temCarteiraDeMotorista = false;

Console.WriteLine(maiorDeIdade && temCarteiraDeMotorista); // false
Console.WriteLine(maiorDeIdade || temCarteiraDeMotorista); // true
Console.WriteLine(!maiorDeIdade);  // false



/*
========= Operadores Compostos (Atribuição) =========
| Operador | Equivalente a |
| -------- | ------------- |
| `+=`     | `a = a + b`   |
| `-=`     | `a = a - b`   |
| `*=`     | `a = a * b`   |
| `/=`     | `a = a / b`   |
| `%=`     | `a = a % b`   |
*/

int numero = 10;

numero += 5;  // 15 // numero = numero + 5
numero -= 3;  // 12 // numero = numero - 3
numero *= 2;  // 24 // numero = numero * 2
numero /= 4;  // 6 // numero = numero / 4
numero %= 4;  // 2 // numero = numero % 4

Console.WriteLine(numero);