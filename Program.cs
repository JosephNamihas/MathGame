// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

Random rnd = new Random();
int numberOne;
int numberTwo;

string? playerAnswer;
string? operationChoice;

StartQuiz();
CalculateAnswer(GenerateQuestion(operationChoice), playerAnswer);


bool IsValidOperation(string? choice)
{
    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("You need to enter a mathematical operation. It can't be empty!");
        return false; // Checks for whitespace / empty strings
    } 
    
    else if (choice != "+" && choice != "-" && choice != "*" && choice != "/") // If choice isn't any of the mathematical operators
    {
        Console.WriteLine("You need to enter a valid operator (+, -, /, *).");
        return false; // Checks for correct characters
    } 

    else {
        return true;
    }
}

string StartQuiz() {
    do
{
    Console.WriteLine("Enter a mathematical operation (+, -, *, /):");
    operationChoice = Console.ReadLine();

} while (!IsValidOperation(operationChoice));

return operationChoice; // while isValidOperation return false, keep running isValidOperation with the operation choice parameter. 

}

double GenerateQuestion(string operation) {

    numberOne = rnd.Next(0, 12);
    numberTwo = rnd.Next(0, 12);
    double answer;
    string tempAnswer;
    switch (operation)
    {
        case "+":
            Console.WriteLine("You chose addition.");
            Console.WriteLine($"What is {numberOne} + {numberTwo}?");
            answer = numberOne + numberTwo;
            return answer;

        case "-":
            Console.WriteLine("You chose subtraction.");
            Console.WriteLine($"What is {numberOne} - {numberTwo}?");
            answer = numberOne - numberTwo;
            playerAnswer = Console.ReadLine();
            double.Parse(playerAnswer);
            return answer;

        case "*":
            Console.WriteLine("You chose multiplication.");
            Console.WriteLine($"What is {numberOne} * {numberTwo}?");
            answer = numberOne * numberTwo;
            playerAnswer = Console.ReadLine();
            double.Parse(playerAnswer);
            return answer;

        case "/":
            Console.WriteLine("You chose division.");
            Console.WriteLine($"What is {numberOne} / {numberTwo}?");
            answer = numberOne / numberTwo;
            playerAnswer = Console.ReadLine();
            double.Parse(playerAnswer);
            return answer;

        default:
            Console.WriteLine("Unexpected operation.");
            return 0;
    }
}

void CalculateAnswer(double answer, double playerAnswer) {
    if (answer == playerAnswer) {
        Console.WriteLine("Correct!");
        StartQuiz();
    } else {
        Console.WriteLine("Incorrect!");
        StartQuiz();
    }

}


