using Spectre.Console;

namespace CodingTracker
{
  class Program
  {
    static void Main(string[] args)
    {
      // todo: 
      // dotnet add package Spectre.Console
      // dotnet add package Spectre.Console.Cli
      // dotnet add package Microsoft.EntityFrameworkCore.Sqlite



      AnsiConsole.Render(new FigletText("Coding Tracker").Centered().Color(Color.Green));
    }
  }
}