public class UserInput
{
    public static int AsInt32(string requestText = null)
    {
        AsInt32Start:
        try
        {
            if(requestText != null) 
            {
                Console.Write(requestText); //if request is not empty, proceed
            }
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsInt32Start;//check if user input is empty, if it is, return to start
            int pharsedInput = Int32.Parse(userInput);//make user input a int32
            return pharsedInput;
        }
        catch(Exception e) 
        {
            Console.WriteLine("To nie jest liczba!");//if its not a int, return to start
            goto AsInt32Start;
        }
    }
    public static string AsString(string requestText = null)
    {
        AsStringStart:
        if (requestText != null)
        {
            Console.Write(requestText);//if request is not empty, proceed
        }
        string userInput = Console.ReadLine();
        if (userInput == "" || userInput == null) goto AsStringStart;//check if user input is empty, if it is, return to start
        return userInput;
    }
    public static float AsFloat(string requestText = null)
    {
        if (requestText != null)
        {
            Console.Write(requestText);//if request is not empty, proceed
        }
        AsFloatStart:
        try
        {
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsFloatStart;//check if user input is empty, if it is, return to start
            float pharsedInput = float.Parse(userInput);//make user input a float
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie jest liczba!");//if its not a float, return to start
            goto AsFloatStart;
        }
    }
    public static DateTime AsDateTime(string requestText = null)
    {
        if (requestText != null)
        {
            Console.Write(requestText);//if request is not empty, proceed
        }
        AsDateTime:
        try
        {
            string userInput = Console.ReadLine();
            if (userInput == "" || userInput == null) goto AsDateTime;//check if user input is empty, if it is, return to start
            DateTime pharsedInput = DateTime.Parse(userInput);// make user input date and time format
            return pharsedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("To nie poprawny format daty!\nFormat: \"08/18/2018 07:22:16\"");//if its not a correct date and time format, return to start
            goto AsDateTime;
        }
    }
}