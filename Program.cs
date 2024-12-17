// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
string? operationChoice;

do
{
    Console.WriteLine("Enter a mathematical operation (+, -, *, /):");
    operationChoice = Console.ReadLine();

} while (!IsValidOperation(operationChoice));

ChooseOperation(operationChoice!);

bool IsValidOperation(string? choice)
{
    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("You need to enter a mathematical operation. It can't be empty!");
        return false;
    }

    if (choice != "+" && choice != "-" && choice != "*" && choice != "/")
    {
        Console.WriteLine("You need to enter a valid operator (+, -, /, *).");
        return false;
    }

    return true;
}

void ChooseOperation(string operation) {
    switch (operation)
    {
        case "+":
            Console.WriteLine("You chose addition.");
            break;

        case "-":
            Console.WriteLine("You chose subtraction.");
            break;

        case "*":
            Console.WriteLine("You chose multiplication.");
            break;

        case "/":
            Console.WriteLine("You chose division.");
            break;

        default:
            Console.WriteLine("Unexpected operation.");
            break;
    }
}

