namespace DrinksInfo
{
    public class Validator
    {

        // create a method that checks if the input is a string and is valid
        public static bool IsStringValid(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!Char.IsLetter(c) && c != '/' && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

    }
}