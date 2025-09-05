namespace SportOrganizer;

class Program
{
    static public int? ExitCode;
    static void Main(string[] args)
    {
        ExitCode = null;
        StartOfMain:
        TUI.PrintMainMenu();
        int UserChoice = UserInput.AsInt32();
        switch(UserChoice)
        {
            default:
                goto StartOfMain;
            case 1: // dodaj gracza
                Player player = new Player();
                player.name = UserInput.AsString("Podaj imię gracza: ");
                break;
        }
    }
}





