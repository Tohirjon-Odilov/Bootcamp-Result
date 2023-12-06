// See https://aka.ms/new-console-template for more information
Console.WriteLine("Salom, Dunyo");
Console.WriteLine("Calculator!");

Console.WriteLine("Enter the number: ");
Console.Write("Enter the a = ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the b: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter ishora: ");
char hint = Convert.ToChar(Console.Read());

switch(hint) 
{
    case '+':
        Console.WriteLine(a+b);
        break;
    case '-':
        Console.WriteLine(a - b);
        break;
    case '*':
        Console.WriteLine(a * b);
        break;
    case '/':
        Console.WriteLine(a / b);
        break;
    default: 
        Console.WriteLine("Error");
        break;