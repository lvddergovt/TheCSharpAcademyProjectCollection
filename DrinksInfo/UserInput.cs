using System;

namespace DrinksInfo
{
    public class UserInput
    {
        DrinksService drinksService = new DrinksService();

        internal void GetCategoriesInput()
        {
            drinksService.GetCategories();

            Console.WriteLine("Please enter the category you want to see: ");
            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("Please enter a valid category: ");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        internal void GetDrinksInput(string category)
        {
            drinksService.GetDrinksByCategory(category);
        }
    }
}