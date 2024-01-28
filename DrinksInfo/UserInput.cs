namespace DrinksInfo
{
    public class UserInput
    {
        DrinksService drinksService = new DrinksService();

        internal void GetCategoriesInput()
        {
            drinksService.GetCategories();
        }
    }
}