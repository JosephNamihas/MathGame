// See https://aka.ms/new-console-template for more information


Random rnd = new Random();
int numberOne;
int numberTwo;
double answer = 0;

string? operationChoice;

StartQuiz();
GenerateQuestion(operationChoice);
Console.WriteLine(CompareAnswers(answer));




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

string GenerateQuestion(string operation) {

    numberOne = rnd.Next(0, 12);
    numberTwo = rnd.Next(0, 12);
    string question;
    switch (operation)
    {
        case "+":
            Console.WriteLine("You chose addition.");
            Console.WriteLine($"What is {numberOne} + {numberTwo}");
            question = $"What is {numberOne} + {numberTwo}?";
            answer = numberOne + numberTwo;

            return question;

        case "-":
            Console.WriteLine("You chose subtraction.");
            question = $"What is {numberOne} - {numberTwo}?";
            answer = numberOne - numberTwo;
            return question;

        case "*":
            Console.WriteLine("You chose multiplication.");
            question = $"What is {numberOne} * {numberTwo}?";
            answer = numberOne * numberTwo;
            return question;

        case "/":
            Console.WriteLine("You chose division.");
            question = $"What is {numberOne} / {numberTwo}?";
            answer = numberOne / numberTwo;
            return question;

        default:
            Console.WriteLine("Unexpected operation.");
            return "Please restart quiz";
    }
}

bool CompareAnswers(double answer) {
    string answerPrompt = Console.ReadLine();
    double playerAnswer = double.Parse(answerPrompt);

    if(answer == playerAnswer) {
        return true;
    } else {
        return false;
    }

}



