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
            string path = Console.ReadLine();//give the name pls

			if (string.IsNullOrWhiteSpace(path))
				path= "thelist.txt";//if didnt give the name make it deafult

            using (StreamWriter Writer = new StreamWriter(path))
			{
				Writer.WriteLine("[Players]");//the lable for players
				foreach(Player _player in Program.playerList)
					Writer.WriteLine($"{_player.name}|{_player.surname}|{_player.age}|{_player.kdr}");//save the info pls

                Writer.WriteLine("[Match]");//the lable for matches
                foreach (Match _match in Program.matchList)
                    Writer.WriteLine($"{_match.teamOnePoints}|{_match.teamTwoPoints}|{_match.teamOneindex}|{_match.teamTwoindex}|{_match.startOfMatch}|{_match.matchTime}|{_match.teamWon}");//safe the info pls

                Writer.WriteLine("[Team]");//the lable for the teams
                foreach (Team _team in Program.teamList)
                {
                    string convertedPlayersIndexes = "";
                    foreach (int playerIndex in _team.playersIndexes)
                    {
                        convertedPlayersIndexes = convertedPlayersIndexes + Convert.ToString(playerIndex) + "\\";
                    }
                    
                    Writer.WriteLine($"{convertedPlayersIndexes}|{_team.teamName}|{_team.gamesWon}|{_team.gamesLost}|{_team.gamesTied}|{_team.captainName}");//safe the info pls
                }

                Console.WriteLine($"zapisano dane do pliku: {path}");
            }
        }
		public static void theload()//DunDun
		{
            Program.matchList.Clear();
            Program.playerList.Clear();//clean THE lists so we dont merge the data with the old ones
            Program.teamList.Clear();

            string loadpath = UserInput.AsString("podaj nazwe pliku do załadowania: ");//give the loadpath pls

            using(StreamReader Reader = new StreamReader(loadpath))
			{
                string line;
                string readType=null;
                while ((line = Reader.ReadLine()) != null)//when not nothing procced
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
                                string[] splitString = line.Split('|');
                                Match match = new Match(); 
                                match.teamOnePoints = int.Parse(splitString[0]);
                                match.teamTwoPoints = int.Parse(splitString[1]);
                                match.teamOneindex = int.Parse(splitString[2]);
                                match.teamTwoindex = int.Parse(splitString[3]);
                                match.startOfMatch = DateTime.Parse(splitString[4]);
                                match.matchTime = float.Parse(splitString[5]);
                                match.teamWon = splitString[6];
                                Program.matchList.Add(match); // Ooooooo the story of undertale
                            }
                            break;
                        case "Team":
                            if (!(line == "[Team]")) // ignore if this is a label line
                            {
                                Team team = new Team();
                                string[] splitString = line.Split('|');//split everything so its more easy to read ig
                                string[] splitPlayerIndexes = splitString[0].Split('\\');
                                for ( int i = 0; i< splitPlayerIndexes.Length;i++) // playerIndexes
                                {
                                    if (!(splitPlayerIndexes[i] == ""))
                                    {
                                        Console.WriteLine(splitPlayerIndexes.Length);
                                        Console.WriteLine();
                                        Console.WriteLine(i);
                                        team.playersIndexes.Add(int.Parse(splitPlayerIndexes[i])); // god ... ah yes god
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
