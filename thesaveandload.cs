using System;
using System.IO;

namespace SportOrganizer
{
	public class thesaveandload
	{
		static void thesave()
		{
            Console.Write("podaj nazwe pliku do zapisu:");
            string path = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
				path= "thelist.txt";

            using (StreamWriter Writer = new StreamWriter(path))
			{
				Writer.WriteLine("[Players]");
				foreach(Player _player in playerList)
					Writer.WriteLine($"{_player.name},{_player.surname},{_player.age},{_player.kdr}");

                Writer.WriteLine("[matches]");
                foreach (Match _match in MatchList)
                    Writer.WriteLine($"{_match.teamOnePoints},{_match.teamTwoPoints},{_match.teamOneindex},{_match.teamTwoindex},{_match.startOfMatch},{_match.matchTime},{_match.teamWon}");

                Writer.WriteLine("[Teams]");
                foreach (Teams _team in TeamList)
                    Writer.WriteLine($"{_team.playersIndexes},{_team.teamName},{_team.gamesWon},{_team.gamesLost},{_team.gamesTied},{_team.captainName}");

                Console.WriteLine($"zapisano dane do pliku: {path}");
            }
        }
		static void theload()
		{
			Console.Write("podaj nazwe pliku do załadowania");
            string loadpath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(loadpath))
				loadpath="thelist.txt";

            using (StreamReader Reader = new StreamReader(loadpath))
			{
				foreach(Player _player in playerlist)
					Reader.ReadLine($"{_player.name},{_player.surname},{_player.age},{_player.kdr}");

                foreach (Match _match in MatchList)
                    Reader.ReadLine($"{_match.teamOnePoints},{_match.teamTwoPoints},{_match.teamOneindex},{_match.teamTwoindex},{_match.startOfMatch},{_match.matchTime},{_match.teamWon}");

                foreach (Teams _team in TeamList)
                    Reader.ReadLine($"{_team.playersIndexes},{_team.teamName},{_team.gamesWon},{_team.gamesLost},{_team.gamesTied},{_team.captainName}");

                Console.WriteLine($"zaladowano dane z pliku: {loadpath}");
            }
		}
	}
}

