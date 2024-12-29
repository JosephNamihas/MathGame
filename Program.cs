// See https://aka.ms/new-console-template for more information

Random rnd = new Random();
int numberOne;
int numberTwo;
int score = 0;
List <string> questionList = new List <string>();
string question = "";
double answer = 0;

string? operationChoice;

GameFlow();

void GameFlow() {
    StartQuiz();
    GenerateQuestion(operationChoice);

    Console.WriteLine($"{CompareAnswers(answer)}! Your score is {score}");

    ViewQuestionList();
}

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
            Console.WriteLine($"What is {numberOne} - {numberTwo}?");
            question = $"What is {numberOne} - {numberTwo}?";
            answer = numberOne - numberTwo;
            return question;

        case "*":
            Console.WriteLine("You chose multiplication.");
            Console.WriteLine($"What is {numberOne} * {numberTwo}?");
            question = $"What is {numberOne} * {numberTwo}?";
            answer = numberOne * numberTwo;
            return question;

        case "/":
        // Question must result in a modulus of 0;
            Console.WriteLine("You chose division.");
            Console.WriteLine($"What is {numberOne} / {numberTwo}?");
            question = $"What is {numberOne} / {numberTwo}?";
            answer = numberOne / numberTwo;
            return question;

        default:
            Console.WriteLine("Unexpected operation.");
            return "Please restart quiz";
    }
}

bool CompareAnswers(double answer) {
    string? answerPrompt = Console.ReadLine();
    double playerAnswer = double.Parse(answerPrompt);

    if(answer == playerAnswer) {
        score += 1;
        questionList.Add(question);
        return true;
    } else {
        return false;
    }
}

void ViewQuestionList() {
    Console.WriteLine("Press q to view the question list, otherwise any other key to continue");
    string? viewQuestions = Console.ReadLine();

    /*if(string.IsNullOrWhiteSpace(viewQuestions)) {
    Console.WriteLine("Press q to view the question list, otherwise any other key to continue");
    }*/

    viewQuestions.ToLower();

    if (viewQuestions == "q") {
        QuestionList();
        Console.WriteLine("Press any key to go to the next question");
        Console.ReadKey();
        GameFlow();
    } else {
        GameFlow();
    }
}

void QuestionList() {

    Console.WriteLine("Previous Questions: ");

    foreach(string item in questionList) {
        Console.WriteLine($"{item}\n");
    }
}


