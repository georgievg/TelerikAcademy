using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweepers
{
	public class Mines
	{
		static void Main ()
		{
			string command = "";
			char[,] field = CreateGameField ();
			char[,] bombs = InsertBombs ();
			int scoreCounter = 0;
			bool dead = false;
			List<Score> winners = new List<Score> (6);
			int row = 0;
			int col = 0;
			bool justStarted = true;
			const int maks = 35;
			bool ending = false;

			do 
			{
				if (justStarted) 
				{
					Console.WriteLine ("Hajde da igraem na “Minesweepers”. Probvaj si kasmeta da otkriesh poleteta bez Minesweepers." +
						" command 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!"
					);
					ClearField (field);
					justStarted = false;
				}
				Console.Write ("Daj row i col : ");
				command = Console.ReadLine();
				if (command.Length >= 3) 
				{
					if (int.TryParse (command [0].ToString (), out row) &&
						int.TryParse (command [2].ToString (), out col) &&
						row <= field.GetLength (0) && col <= field.GetLength (1)) 
					{
						command = "turn";
					}
				}
				switch (command) 
				{
				case "top":
					Scoreboard (winners);
					break;
				case "restart":
					field = CreateGameField ();
					bombs = InsertBombs ();
					ClearField (field);
					dead = false;
					justStarted = false;
					break;
				case "exit":
					Console.WriteLine ("4a0, 4a0, 4a0!");
					break;
				case "turn":
					if (bombs [row, col] != '*') 
					{
						if (bombs [row, col] == '-') 
						{
							PlayerOnTurn (field, bombs, row, col);
							scoreCounter++;
						}
						if (maks == scoreCounter) {
							ending = true;
						} 
						else 
						{
							ClearField (field);
						}
					} 
					else 
					{
						dead = true;
					}
					break;
				default:
					Console.WriteLine ("\nGreshka! nevalidna command\n");
					break;
				
				}
				if (dead) 
				{
					ClearField (bombs);
					Console.Write ("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si nickName: ", scoreCounter);
					string nickName = Console.ReadLine ();
					Score ScoreStats = new Score (nickName, scoreCounter);
					if (winners.Count < 5) 
					{
						winners.Add (ScoreStats);
					} 
					else 
					{
						for (int i = 0; i < winners.Count; i++) 
						{
							if (winners [i].Scores < ScoreStats.Scores) 
							{
								winners.Insert (i, ScoreStats);
								winners.RemoveAt (winners.Count - 1);
								break;
							}
						}
					}
					winners.Sort ((Score r1, Score r2) => r2.Name.CompareTo (r1.Name));
					winners.Sort ((Score r1, Score r2) => r2.Scores.CompareTo (r1.Scores));
					Scoreboard (winners);

					field = CreateGameField ();
					bombs = InsertBombs ();
					scoreCounter = 0;
					dead = false;
					justStarted = true;
				}
				if (ending) 
				{
					Console.WriteLine ("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					ClearField (bombs);
					Console.WriteLine ("Daj si imeto, batka: ");
					string name = Console.ReadLine ();
					Score ScoreStats = new Score (name, scoreCounter);
					winners.Add (ScoreStats);
					Scoreboard (winners);
					field = CreateGameField ();
					bombs = InsertBombs ();
					scoreCounter = 0;
					ending = false;
					justStarted = true;
				}
			} 
			while (command != "exit");
			Console.WriteLine ("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine ("AREEEEEEeeeeeee.");
			Console.Read ();
		}

		private static void Scoreboard (List<Score> ScoreStats)
		{
			Console.WriteLine ("\nTo4KI:");
			if (ScoreStats.Count > 0) 
			{
				for (int i = 0; i < ScoreStats.Count; i++) 
				{
					Console.WriteLine ("{0}. {1} --> {2} kutii",
						i + 1, ScoreStats [i].Name, ScoreStats [i].Scores);
				}
				Console.WriteLine ();
			}
			else 
			{
				Console.WriteLine ("prazna klasaciq!\n");
			}
		}

		private static void PlayerOnTurn (char[,] field,
			char[,] bombs, int row, int col)
		{
			char bombsAmount = getPosValue (bombs, row, col);
			bombs [row, col] = bombsAmount;
			field [row, col] = bombsAmount;
		}

		private static void ClearField (char[,] board)
		{
			int rows = board.GetLength (0);
			int cols = board.GetLength (1);
			Console.WriteLine ("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine ("   ---------------------");
			for (int i = 0; i < rows; i++) 
			{
				Console.Write ("{0} | ", i);
				for (int j = 0; j < cols; j++) 
				{
					Console.Write (string.Format ("{0} ", board [i, j]));
				}
				Console.Write ("|");
				Console.WriteLine ();
			}
			Console.WriteLine ("   ---------------------\n");
		}

		private static char[,] CreateGameField ()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++) 
			{
				for (int j = 0; j < boardColumns; j++) 
				{
					board [i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] InsertBombs ()
		{
			int rows = 5;
			int cols = 10;
			char[,] gameField = new char[rows, cols];

			for (int i = 0; i < rows; i++) 
			{
				for (int j = 0; j < cols; j++) 
				{
					gameField [i, j] = '-';
				}
			}

			List<int> bombsList = new List<int> ();
			Random random = new Random ();
			while (bombsList.Count < 15) 
			{
				int rndNumb = random.Next (50);
				if (!bombsList.Contains (rndNumb)) 
				{
					bombsList.Add (rndNumb);
				}
			}

			foreach (int bomb in bombsList) {
				int col = (bomb / cols);
				int row = (bomb % cols);
				if (row == 0 && bomb != 0) {
					col--;
					row = cols;
				} 
				else 
				{
					row++;
				}
				gameField [col, row - 1] = '*';
			}

			return gameField;
		}

		private static void Calculations (char[,] field)
		{
			int col = field.GetLength (0);
			int row = field.GetLength (1);

			for (int i = 0; i < col; i++) 
			{
				for (int j = 0; j < row; j++) 
				{
					if (field [i, j] != '*') 
					{
						char posValue = getPosValue (field, i, j);
						field [i, j] = posValue;
					}
				}
			}
		}

		private static char getPosValue (char[,] field, int row, int col)
		{
			int valCounter = 0;
			int rows = field.GetLength (0);
			int cols = field.GetLength (1);

			if (row - 1 >= 0) 
			{
				if (field [row - 1, col] == '*') 
				{ 
					valCounter++; 
				}
			}
			if (row + 1 < rows) 
			{
				if (field [row + 1, col] == '*') 
				{ 
					valCounter++; 
				}
			}
			if (col - 1 >= 0) 
			{
				if (field [row, col - 1] == '*') 
				{ 
					valCounter++;
				}
			}
			if (col + 1 < cols) 
			{
				if (field [row, col + 1] == '*') 
				{ 
					valCounter++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0)) 
			{
				if (field [row - 1, col - 1] == '*') 
				{ 
					valCounter++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols)) 
			{
				if (field [row - 1, col + 1] == '*') 
				{ 
					valCounter++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0)) 
			{
				if (field [row + 1, col - 1] == '*') 
				{ 
					valCounter++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols)) 
			{
				if (field [row + 1, col + 1] == '*') 
				{ 
					valCounter++; 
				}
			}
			return char.Parse (valCounter.ToString());
		}
	}
}