using System;
using System.IO;
namespace SportOrganizer
{
	public class thesaveandload
	{
		static void thesave()
		{
            Console.Write("podaj nazwe pliku do zapisu:")
			string path = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
				path= "thelist.txt"

			using (StreamWriter Writer = new StreamWriter(path))
			{
				Writer.WriteLine("[Players]");
				foreach(Player _player in playerList)
					Writer.WriteLine($"{_player.name},{_player.surname},{_player.age},{_player.kdr}")

                Writer.WriteLine("[matches]");
                foreach (Match _match in MatchList)
                    Writer.WriteLine($"{_match.name},{_match.surname},{_match.age},{_match.kdr}")

                Writer.WriteLine("[Teams]");
                foreach (Teams _team in TeamList)
                    Writer.WriteLine($"{_team.name},{_team.surname},{_team.age},{_team.kdr}")

				Console.WriteLine($"zapisano dane do pliku: {path}")
            }

            static void theload()

        }
	}
}

