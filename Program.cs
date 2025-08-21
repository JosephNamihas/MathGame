// See https://aka.ms/new-console-template for more information

Random rnd = new Random();
int numberOne = 0;
int numberTwo = 0;
int score = 0;

List<string> questionList = new List<string>();
List<double> answerList = new List<double>();

Dictionary<string, double> pastQuestions = new Dictionary<string, double>();

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

    switch (operation)
    {
        case "+":
            numberOne = rnd.Next(0, 99);
            numberTwo = rnd.Next(0, 99);
            Console.WriteLine("You chose addition.");
            Console.WriteLine($"What is {numberOne} + {numberTwo}");
            question = $"What is {numberOne} + {numberTwo}?";
            answer = numberOne + numberTwo;

            return question;

        case "-":
            numberOne = rnd.Next(0, 99);
            numberTwo = rnd.Next(0, 99);
            Console.WriteLine("You chose subtraction.");
            Console.WriteLine($"What is {numberOne} - {numberTwo}?");
            question = $"What is {numberOne} - {numberTwo}?";
            answer = numberOne - numberTwo;
            return question;

        case "*":
            numberOne = rnd.Next(0, 12);
            numberTwo = rnd.Next(0, 12);
            Console.WriteLine("You chose multiplication.");
            Console.WriteLine($"What is {numberOne} * {numberTwo}?");
            question = $"What is {numberOne} * {numberTwo}?";
            answer = numberOne * numberTwo;
            return question;

        case "/":
        Console.WriteLine("You chose division");
            return DivisionLogic(numberOne, numberTwo);

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
        pastQuestions.Add(question, answer);
        return true;
    } else {
        return false;
    }
}

void ViewQuestionList() {
    Console.WriteLine("Press q to view the question list, otherwise any other key to continue");
    Console.WriteLine("Press e to exit the application");
    string? viewQuestions = Console.ReadLine();

    /*if(string.IsNullOrWhiteSpace(viewQuestions)) {
    Console.WriteLine("Press q to view the question list, otherwise any other key to continue");
    }*/

    viewQuestions.ToLower();

    if (viewQuestions == "e")
    {
        Environment.Exit(0);

    }

    if (viewQuestions == "q") {
        QuestionList();
        Console.WriteLine("Press any key to go to the next question");
        Console.ReadKey();
        GameFlow();
    } else {
        GameFlow();
    }
}

void QuestionList()
{

    Console.WriteLine("Previous Questions: ");

    foreach (KeyValuePair<string, double> entry in pastQuestions)
    {
        Console.WriteLine($"Question: {entry.Key}\t Answer: {entry.Value}");
    }
}

string DivisionLogic(int numberOne, int numberTwo) {

    do {
        numberOne = rnd.Next(1, 99);
        numberTwo = rnd.Next(1, 12);

    } while (numberOne % numberTwo != 0); 

        Console.WriteLine($"What is {numberOne} / {numberTwo}?");
        question = $"What is {numberOne} / {numberTwo}?";
        answer = numberOne / numberTwo;
        return question;
    }


