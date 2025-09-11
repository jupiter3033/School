public class UserInput
{
    public static int AsInt32(string requestText = null)
    {
        AsInt32Start:
        try
        {
            if(requestText != null)
            {
                Console.Write(requestText);
            }
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsInt32Start;
            int pharsedInput = Int32.Parse(userInput);
            return pharsedInput;
        }
        catch(Exception e)
        {
            Console.WriteLine("To nie jest liczba!");
            goto AsInt32Start;
        }
    }
    public static string AsString(string requestText = null)
    {
        AsStringStart:
        if (requestText != null)
        {
            Console.Write(requestText);
        }
        string userInput = Console.ReadLine();
        if (userInput == "" || userInput == null) goto AsStringStart;
        return userInput;
    }
    public static float AsFloat(string requestText = null)
    {
        if (requestText != null)
        {
            Console.Write(requestText);
        }
        AsFloatStart:
        try
        {
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsFloatStart;
            float pharsedInput = float.Parse(userInput);
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie jest liczba!");
            goto AsFloatStart;
        }
    }
    public static DateTime AsDateTime(string requestText = null)
    {
        if (requestText != null)
        {
            Console.Write(requestText);
        }
        AsDateTime:
        try
        {
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsDateTime;
            DateTime pharsedInput = DateTime.Parse(userInput);
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie poprawny format daty!\nFormat: \"08/18/2018 07:22:16\"");
            goto AsDateTime;
        }
    }
}