using System;
using System.Diagnostics.Metrics;
using System.IO;

namespace SportOrganizer
{
	public class thesaveandload
	{
		public static void thesave()
		{
            Console.Write("podaj nazwe pliku do zapisu:");
            string path = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
				path= "thelist.txt";

            using (StreamWriter Writer = new StreamWriter(path))
			{
				Writer.WriteLine("[Players]");
				foreach(Player _player in Program.playerList)
					Writer.WriteLine($"{_player.name}|{_player.surname}|{_player.age}|{_player.kdr}");

                Writer.WriteLine("[Match]");
                foreach (Match _match in Program.matchList)
                    Writer.WriteLine($"{_match.teamOnePoints}|{_match.teamTwoPoints}|{_match.teamOneindex}|{_match.teamTwoindex}|{_match.startOfMatch}|{_match.matchTime}|{_match.teamWon}");

                Writer.WriteLine("[Team]");
                foreach (Team _team in Program.teamList)
                {
                    string convertedPlayersIndexes = "";
                    foreach (int playerIndex in _team.playersIndexes)
                    {
                        convertedPlayersIndexes = convertedPlayersIndexes + Convert.ToString(playerIndex) + "\\";
                    }
                    
                    Writer.WriteLine($"{convertedPlayersIndexes}|{_team.teamName}|{_team.gamesWon}|{_team.gamesLost}|{_team.gamesTied}|{_team.captainName}");
                }

                Console.WriteLine($"zapisano dane do pliku: {path}");
            }
        }
		public static void theload()
		{
            string loadpath = UserInput.AsString("podaj nazwe pliku do załadowania: ");

            using(StreamReader Reader = new StreamReader(loadpath))
			{
                string line;
                string readType=null;
                while ((line = Reader.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    if (line == "[Players]") readType = "Player";
                    if (line == "[Match]") readType = "Match";
                    if (line == "[Team]") readType = "Team";
                    switch(readType)
                    {
                        default:
                            //Do nothing
                            break;
                        case "Player":
                            if (!(line == "[Players]")) // ignore if this is a label line
                            {
                                string[] splitString = line.Split('|');
                                Player player = new Player();
                                player.name = splitString[0];
                                player.surname = splitString[1];
                                player.age = int.Parse(splitString[2]);
                                player.kdr = float.Parse(splitString[3]);
                                Program.playerList.Add(player);
                            }
                            break;
                        case "Match":
                            if (!(line == "[Match]")) // ignore if this is a label line
                            {
                                Console.WriteLine(line); // WIP.
                            }
                            break;
                        case "Team":
                            if (!(line == "[Team]")) // ignore if this is a label line
                            {
                                Team team = new Team();
                                string[] splitString = line.Split('|');
                                string[] splitPlayerIndexes = splitString[0].Split('\\');
                                for ( int i = 0; i< splitPlayerIndexes.Length;i++) // playerIndexes
                                {
                                    if (!(splitPlayerIndexes[i] == ""))
                                    {
                                        Console.WriteLine(splitPlayerIndexes.Length);
                                        Console.WriteLine();
                                        Console.WriteLine(i);
                                        team.playersIndexes.Add(int.Parse(splitPlayerIndexes[i])); // god
                                    }
                                }
                                team.teamName = splitString[1];
                                team.gamesWon = int.Parse(splitString[2]);
                                team.gamesLost = int.Parse(splitString[3]);
                                team.gamesTied = int.Parse(splitString[4]);
                                team.captainName = splitString[5];
                                Program.teamList.Add(team);
                            }
                            break;
                    }
                }
                Console.WriteLine($"zaladowano dane z pliku: {loadpath}");
            }
		}
	}
}