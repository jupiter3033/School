public class UserInput
{
    public static int AsInt32(string requestText = null)
    {
        AsInt32Start:
        try
        {
            if(requestText == null)
            {
                Console.WriteLine(requestText);
            }
            string userInput = Console.ReadLine();
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
        if (requestText == null)
        {
            Console.WriteLine(requestText);
        }
        return Console.ReadLine();
    }
    public static float AsFloat()
    {
        AsFloatStart:
        try
        {
            string userInput = Console.ReadLine();
            float pharsedInput = float.Parse(userInput);
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie jest liczba!");
            goto AsFloatStart;
        }
    }
    public static DateTime AsDateTime()
    {
        AsDateTime:
        try
        {
            string userInput = Console.ReadLine();
            DateTime pharsedInput = DateTime.Parse(userInput);
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie jest data!\nFormat: \"08/18/2018 07:22:16\"");
            goto AsDateTime;
        }
    }
}