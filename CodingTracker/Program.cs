
namespace CodingTracker
{
	class Program
	{
		static void Main(string[] args)
		{

			var codingSessionController = new CodingSessionController();
			var consoleMenu = new ConsoleMenu(codingSessionController);
			consoleMenu.DisplayMenu();

		}
	}
}