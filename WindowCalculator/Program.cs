// See https://aka.ms/new-console-template for more information
using WindowCalculator;

Console.WriteLine("Welcome to the Window Calculator!");
Console.WriteLine();
Console.WriteLine("The Window Calculator helps you sum the number of windows on two buildings.");
Console.WriteLine();

while (true)
{
    Console.Write("Write the number of windows on the first building: ");
    string? number1 = Console.ReadLine();
    Console.Write("Write the number of windows on the second building: ");
    string? number2 = Console.ReadLine();
    Console.WriteLine();

    var result = Calculator.Calculate(number1, number2);

    Console.Write($"The total number of windows on the buildings are: ");
    Console.WriteLine(result);
    Console.WriteLine();
    Console.WriteLine();
}