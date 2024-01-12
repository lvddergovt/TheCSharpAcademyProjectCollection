/// <summary>
/// This program allows the user to play a math game by choosing a game mode (addition, subtraction, multiplication, or division) and answering math questions.
/// </summary>


Console.WriteLine("Please enter your name: ");
string? userName = Console.ReadLine();
DateTime now = DateTime.Now;
bool keepPlaying = true;
List<string> gameHistory = new List<string>();

// while keepplaying is true, keep playing the game
while (keepPlaying)
{
  // ask the user to choose a game mode and give them the options
  Console.WriteLine($"Hi {userName}, today is {now} and it's time to play a math game. \nPlease choose a game mode: ");
  Console.WriteLine("A - addition");
  Console.WriteLine("S - subtraction");
  Console.WriteLine("M - multiplication");
  Console.WriteLine("D - division");
  Console.WriteLine("H - display game history");
  Console.WriteLine("Q - quit");

  // read the user's input
  string? gameMode = Console.ReadLine();

  // create a list to store the game history

  // check if the user's input is not empty
  if (string.IsNullOrEmpty(gameMode))
  {
    Console.WriteLine("Please enter a game mode!");
  }
  else
  {
    if (gameMode.ToLower().Trim() == "a")
    {
      Addition();
    }
    else if (gameMode.ToLower().Trim() == "s")
    {
      Subtraction();
    }
    else if (gameMode.ToLower().Trim() == "m")
    {
      Multiplication();
    }
    else if (gameMode.ToLower().Trim() == "d")
    {
      Division();
    }
    else if (gameMode.ToLower().Trim() == "q")
    {
      Console.WriteLine("Goodbye!");
      keepPlaying = false;
    }
    else if (gameMode.ToLower().Trim() == "h")
    {
      DisplayHistory();
    }
    else
    {
      Console.WriteLine("Invalid game mode!");
    }
  }
}

// create the addition game mode in a function
void Addition()
{
  // create a random number generator
  Random random = new Random();

  // create 2 random numbers
  int num1 = random.Next(1, 11);
  int num2 = random.Next(1, 11);

  // ask the user to add the 2 numbers together
  Console.WriteLine($"What is {num1} + {num2}?");
  int answer = Convert.ToInt32(Console.ReadLine());

  // check if the user's answer is correct
  if (answer == num1 + num2)
  {
    Console.WriteLine("Correct!");
    gameHistory.Add($"Addition game: {num1} + {num2} = {answer} (Correct)");

  }
  else
  {
    Console.WriteLine("Incorrect!");
    gameHistory.Add($"Addition game: {num1} + {num2} = {answer} (Incorrect)");
  }
}

// create the subtraction game mode in a function
void Subtraction()
{
  // create a random number generator
  Random random = new Random();

  // create 2 random numbers
  int num1 = random.Next(1, 11);
  int num2 = random.Next(1, 11);

  // ask the user to subtract the 2 numbers
  Console.WriteLine($"What is {num1} - {num2}?");
  int answer = Convert.ToInt32(Console.ReadLine());

  // check if the user's answer is correct
  if (answer == num1 - num2)
  {
    Console.WriteLine("Correct!");
    gameHistory.Add($"Subtraction game: {num1} - {num2} = {answer} (Correct)");
  }
  else
  {
    Console.WriteLine("Incorrect!");
    gameHistory.Add($"Subtraction game: {num1} - {num2} = {answer} (Incorrect)");
  }
}

// create the multiplication game mode in a function
void Multiplication()
{
  // create a random number generator
  Random random = new Random();

  // create 2 random numbers
  int num1 = random.Next(1, 11);
  int num2 = random.Next(1, 11);

  // ask the user to multiply the 2 numbers
  Console.WriteLine($"What is {num1} * {num2}?");
  int answer = Convert.ToInt32(Console.ReadLine());

  // check if the user's answer is correct
  if (answer == num1 * num2)
  {
    Console.WriteLine("Correct!");
    gameHistory.Add($"Multiplication game: {num1} - {num2} = {answer} (Correct)");
  }
  else
  {
    Console.WriteLine("Incorrect!");
    gameHistory.Add($"Multiplication game: {num1} - {num2} = {answer} (Incorrect)");
  }
}

// create the division game mode in a function
void Division()
{
  // create a random number generator
  Random random = new Random();

  // create 2 random numbers
  int num1 = random.Next(1, 11);
  int num2 = random.Next(1, 11);

  // ask the user to divide the 2 numbers
  Console.WriteLine($"What is {num1} / {num2}?");
  int answer = Convert.ToInt32(Console.ReadLine());

  // check if the user's answer is correct
  if (answer == num1 / num2)
  {
    Console.WriteLine("Correct!");
    gameHistory.Add($"Division game: {num1} - {num2} = {answer} (Correct)");
  }
  else
  {
    Console.WriteLine("Incorrect!");
    gameHistory.Add($"Division game: {num1} - {num2} = {answer} (Incorrect)");
  }
}

// create a function to display the game history
void DisplayHistory()
{
  Console.WriteLine("Game History:");
  foreach (string gameResult in gameHistory)
  {
    Console.WriteLine(gameResult);
  }
}