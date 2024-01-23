using Spectre.Console;

namespace CodingTracker
{
  class Program
  {
    static void Main(string[] args)
    {




      AnsiConsole.Render(new FigletText("Coding Tracker").Centered().Color(Color.Green));
    }
  }
}