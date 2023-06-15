//Rozgrzewka 1
using System;

Console.WriteLine("Hello, World!");


//Rozgrzewka 2
//Console.WriteLine("Podaj swoje imię:");
//var name = Console.ReadLine();
//Console.WriteLine("Hello " + name);

//Rozgrzewka 3
int result = 5 + 9;

//Operatory 1
int number = 4;
float money = 21.4f;
string text = "tekst";
bool isLogged = true;
char myChar = 's';
decimal price = 20.5m;


Console.WriteLine("number: " + number);
Console.WriteLine("money: " + money);
Console.WriteLine("text: " + text);
Console.WriteLine("isLogged: " + isLogged);
Console.WriteLine("myChar: " + myChar);
Console.WriteLine("price: " + price);

Console.WriteLine("\n");
//Operatory 2
string myAge = "Age: ";
int wifeAge = 18;
var result2 = myAge+ wifeAge;
Console.WriteLine(result2); //wniosek - result2 jest typu string, w trakcie 'dodawnia' wartości zmienna wifeAge została zamieniona na string


Console.WriteLine("\n");
//Operatory 3
bool isTrue = true;
bool isFalse = false;
bool isReallyTrue = true;
bool and = isTrue && isFalse;
bool or = isTrue || isReallyTrue;
bool negative = !isFalse;

Console.WriteLine("and: " + and);
Console.WriteLine("or: " + or);
Console.WriteLine("negative: " + negative);


Console.WriteLine("\n");
//Operatory 4
int a = 5;
int b = 12;

int add = a + b;
int sub = a - b;
float div = (float)a / b;
int mul = a * b;
int mod = a % b;

Console.WriteLine("add: " + add);
Console.WriteLine("sub: " + sub);
Console.WriteLine("div: " + div);
Console.WriteLine("mul: " + mul);
Console.WriteLine("mod: " + mod);

Console.WriteLine("\n");
//Operatory 5
string s_a = "Ala ";
string s_b = "ma ";
string s_c = "kota.";
string s_result = s_a + s_b + s_c;
Console.WriteLine(s_result); //teksty złączyły się poprawnie

//Sterowanie 1
int n1 = 10;
int n2 = 20;
if (n1 > n2)
    Console.WriteLine("n1 jest większe od n2");
else if (n1 < n2)
    Console.WriteLine("n1 jest mniejsze od n2");
else Console.WriteLine("n1 jest równe n2");

Console.WriteLine("\n");
//Sterowanie 2
for (int j = 0; j < 10; j++)
    Console.Write("C##");
Console.WriteLine("\n");
int i = 0;
while (i < 10) {
    Console.Write("C##");
    i++;
}

Console.WriteLine("\n");
//Sterowanie 3
int n = 10;
for (int j = 0; j <= n; j++)
    Console.WriteLine(j + " - " + (j%2==0 ? "Parzysta" : "Nieparzysta"));

Console.WriteLine("\n");
//Sterowanie 4
int n3 = 5;
for (int j = 0; j <= n3; j++) {
    for (int k = 0; k < j; k++)
        Console.Write("* ");
    Console.WriteLine("");
}

Console.WriteLine("\n");
//Sterowanie 5
int exam = 47;