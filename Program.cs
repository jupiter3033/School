using System.Diagnostics;

namespace SportOrganizer;

class Program
{
    public static List<Player> playerList = new List<Player>();
    public static List<Match> matchList = new List<Match>();
    public static List<Team> teamList = new List<Team>();
    static void Main(string[] args)
    {
        StartOfMain:
        GC.Collect(); //Becouse i can B)
        TUI.PrintMainMenu();
        int UserChoice = UserInput.AsInt32();
        switch(UserChoice)
        {
            default:
                goto StartOfMain;
            case 1: // add player
                Player player = new Player();
                player.name = UserInput.AsString("Podaj imię gracza: ");
                player.surname = UserInput.AsString("Podaj nazwisko gracza: ");
                player.age = UserInput.AsInt32("Podaj wiek gracza: ");
                player.kdr = UserInput.AsFloat("Podaj KDR gracza: ");
                playerList.Add(player);
                goto StartOfMain;
            case 2: // remove player
                if (playerList.Count != 0)
                {
                    PrintAllPlayers(playerList);
                    int indexToRemove = UserInput.AsInt32("Podaj index do usunięcia: ");
                    try
                    {
                        playerList.RemoveAt(indexToRemove-1);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Coś poszło nie tak... : "+ex);
                    }
                }
                else
                    Console.WriteLine("Nie ma co usunąć!");
                
                goto StartOfMain;
            case 4: // add team
                Team team = new Team();
                int i = 0;
                while (i != -1)
                {
                    Console.WriteLine("Podaj indexy graczy ktrórych dodać do drużyny.\n(wpisz 0 aby pokazać wszystkich dostępnych graczy, lub -1 aby zakończyć wpisywanie.)");
                    int userInput = UserInput.AsInt32(">");
                    try
                    {
                        if (userInput > 0) //Index Given
                        {
                            if (team.playersIndexes.Contains(userInput - 1))
                            {
                                Console.WriteLine("Ten gracz jest już w tej drużynie!");
                            }
                            else
                            {
                                Console.WriteLine("Dodano : " + playerList[userInput - 1].name);
                                team.playersIndexes.Add(userInput - 1);
                            }
                        }
                        else // Special Index
                        {
                            if (userInput == 0) PrintAllPlayers(playerList);
                            if (userInput == -1) break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Coś poszło nie tak... czy ten gracz istnieje? (czy to poprawny index?)");
                    }
                    
                }
                team.teamName = UserInput.AsString("Podaj nazwę drużyny: ");
                team.gamesWon = UserInput.AsInt32("Podaj ilość gier wygranych: ");
                team.gamesLost = UserInput.AsInt32("Podaj ilość gier przegranych: ");
                team.gamesTied = UserInput.AsInt32("Podaj ilość gier zakończonych remisem: ");
                team.captainName = UserInput.AsString("Podaj imię kapitana: ");
                teamList.Add(team);
                goto StartOfMain;
            case 6: // create match
                Match match = new Match();
                
                try
                {

                    match.teamOneindex = UserInput.AsInt32("Index Drużuny jeden: ");
                    Team readTest = teamList[match.teamOneindex]; //will crash if team does not exist and thats the point. :P
                    match.teamTwoindex = UserInput.AsInt32("Index Drużuny dwa: ");
                    readTest = teamList[match.teamTwoindex]; // same here
                    match.teamOnePoints = UserInput.AsInt32("Punkty Drużuny jeden: ");
                    match.teamTwoPoints = UserInput.AsInt32("Punkty Drużuny dwa: ");
                    match.startOfMatch = UserInput.AsDateTime("Godzina rozpoczęcia meczu :");
                    match.matchTime = UserInput.AsFloat("Czas trwania meczu: ");
                    match.teamWon = UserInput.AsString("Drużyna Która wygrała (Może być nikt): ");
                    readTest = null; // to be eaten by GC.
                }
                catch
                {
                    Console.WriteLine("Coś poszło nie tak... czy ten gracz istnieje? (czy to poprawny index?)");
                }
                matchList.Add(match);

                /*public int teamOnePoints;
			public int teamTwoPoints;
			public int teamOneindex;
			public int teamTwoindex;
			public DateTime startOfMatch;
			public float matchTime;
			public string teamWon;
	}*/

                goto StartOfMain;
            case 8:
                thesaveandload.thesave(); // WHY DO THEY NEED THE 'the' PART WTF KAPER
                goto StartOfMain;
            case 9:
                thesaveandload.theload();
                goto StartOfMain;
            case 10: // exit
                break;
            case 11: // show all
                PrintAllPlayers(playerList);
                PrintAllTeams(teamList);
                goto StartOfMain;
            case 12: // clear
                Console.Clear();
                goto StartOfMain;
        }
    }
    static void PrintAllPlayers(List<Player> _playerList)
    {
        if (_playerList.Count != 0) // playerz
        {
            Console.WriteLine("Gracze: ");
            int i = 1;
            foreach (Player _player in _playerList)
            {
                Console.WriteLine(i + ".\n     imię gracza: " + _player.name + "\n     nazwisko gracza: " + _player.surname + "\n     wiek gracza: " + _player.age + "\n     KDR gracza: " + _player.kdr);
                i++;
            }
        }
    }
    static void PrintAllTeams(List<Team> _teamList)
    {
        if (_teamList.Count != 0) // teams
        {
            Console.WriteLine("Drużyny: ");
            int i = 1;
            foreach (Team _team in _teamList)
            {
                Console.WriteLine(i + ".\n     imię drużyny: " + _team.teamName + "\n     liczba gier wygranych: " + _team.gamesWon + "\n     liczba gier przegranych: " + _team.gamesLost + "\n     Liczba gier zakończonych remisem: " + _team.gamesTied+"\n     Imie kapitana: "+_team.captainName);
                Console.WriteLine("     Gracze: ");
                foreach(int playerIndex in _team.playersIndexes)
                {
                    Console.WriteLine("     "+playerIndex+". ");
                    Console.WriteLine("     imię gracza: " + playerList[playerIndex].name + "\n     nazwisko gracza: " + playerList[playerIndex].surname);
                }
                i++;
            }
        }
    }
}





