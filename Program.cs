using System.Diagnostics;

namespace SportOrganizer;

class Program
{
    public static List<Player> playerList = new List<Player>(); // list of players
    public static List<Match> matchList = new List<Match>(); // list of matches
    public static List<Team> teamList = new List<Team>(); // list of teams

    static void Main(string[] args)
    {
        StartOfMain:
        GC.Collect();
        TUI.PrintMainMenu(); // print main menu
        int UserChoice = UserInput.AsInt32(); // get user input

        switch(UserChoice)
        {
            default:
                goto StartOfMain; // go back to main menu if input is invalid

            case 1: // add player
                Player player = new Player();
                player.name = UserInput.AsString("Podaj imię gracza: ");
                player.surname = UserInput.AsString("Podaj nazwisko gracza: ");
                player.age = UserInput.AsInt32("Podaj wiek gracza: ");
                player.kdr = UserInput.AsFloat("Podaj KDR gracza: ");
                playerList.Add(player); // add player to list
                goto StartOfMain;

            case 2: // remove player
                if (playerList.Count != 0)
                {
                    PrintAllPlayers(playerList); // show all players
                    int indexToRemove = UserInput.AsInt32("Podaj index do usunięcia: ");
                    try
                    {
                        playerList.RemoveAt(indexToRemove-1); // remove by index
                    catch(Exception ex)
                    {
                        Console.WriteLine("Coś poszło nie tak... : "+ex); // error message if index is invalid
                    }
                }
                else
                    Console.WriteLine("Nie ma co usunąć!");
                
                goto StartOfMain;

            case 4: // add team
                Team team = new Team();
                int i = 0;
                while (i != -1) // loop for adding players to the team
                {
                    Console.WriteLine("Podaj indexy graczy ktrórych dodać do drużyny.\n(wpisz 0 aby pokazać wszystkich dostępnych graczy, lub -1 aby zakończyć wpisywanie.)");
                    int userInput = UserInput.AsInt32(">");
                    try
                    {
                        if (userInput > 0) // player index was given
                        {
                            if (team.playersIndexes.Contains(userInput - 1)) // check if player already in team
                            {
                                Console.WriteLine("Ten gracz jest już w tej drużynie!");
                            }
                            else
                            {
                                Console.WriteLine("Dodano : " + playerList[userInput - 1].name);
                                team.playersIndexes.Add(userInput - 1); // add player index to team
                            }
                        }
                        else
                        {
                            if (userInput == 0) PrintAllPlayers(playerList); // show players
                            if (userInput == -1) break; // finish adding players
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
                teamList.Add(team); // add team to list
                goto StartOfMain;

            case 6: // create match
                Match match = new Match();
                
                try
                {
                    match.teamOneindex = UserInput.AsInt32("Index Drużuny jeden: ");
                    Team readTest = teamList[match.teamOneindex]; // check if team exists
                    match.teamTwoindex = UserInput.AsInt32("Index Drużuny dwa: ");
                    readTest = teamList[match.teamTwoindex]; // check if second team exists
                    match.teamOnePoints = UserInput.AsInt32("Punkty Drużuny jeden: ");
                    match.teamTwoPoints = UserInput.AsInt32("Punkty Drużuny dwa: ");
                    match.startOfMatch = UserInput.AsDateTime("Godzina rozpoczęcia meczu :");
                    match.matchTime = UserInput.AsFloat("Czas trwania meczu: ");
                    match.teamWon = UserInput.AsString("Drużyna Która wygrała (Może być nikt): ");
                    readTest = null;
                }
                catch
                {
                    Console.WriteLine("Coś poszło nie tak... czy ten gracz istnieje? (czy to poprawny index?)");
                }
                matchList.Add(match); // add match to list
                goto StartOfMain;

            case 8: // save data
                thesaveandload.thesave();
                goto StartOfMain;

            case 9: // load data
                thesaveandload.theload();
                goto StartOfMain;

            case 10: // exit program
                break;

            case 11: // show all players and teams
                PrintAllPlayers(playerList);
                PrintAllTeams(teamList);
                goto StartOfMain;

            case 12: // clear console
                Console.Clear();
                goto StartOfMain;
        }
    }

    static void PrintAllPlayers(List<Player> _playerList)
    {
        if (_playerList.Count != 0)
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
        if (_teamList.Count != 0)
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
