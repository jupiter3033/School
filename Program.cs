namespace SportOrganizer;

class Program
{
    static List<Player> playerList = new List<Player>();
    static List<Match> matchList = new List<Match>();
    static List<Team> teamList = new List<Team>();
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
                player.surname = UserInput.AsString("Podaj nazwisko gracza: ");
                player.age = UserInput.AsInt32("Podaj wiek gracza: ");
                player.kdr = UserInput.AsFloat("Podaj KDR gracza: ");
                playerList.Add(player);
                if (ExitCode == null) goto StartOfMain;
                break;
            case 11: // pokaż wszystko
                if(playerList.Count != 0)
                {
                    Console.WriteLine("Gracze: ");
                    int i = 1;
                    foreach (Player _player in playerList)
                    {
                        Console.WriteLine(i+ ".\n     imię gracza: "+_player.name+ "\n     nazwisko gracza: "+_player.surname+ "\n     wiek gracza: "+_player.age+ "\n     KDR gracza: "+_player.kdr);
                    }
                }
                if (ExitCode == null) goto StartOfMain;
                break;
        }
    }
}





