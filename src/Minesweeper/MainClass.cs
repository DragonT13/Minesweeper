﻿using System;

namespace Minesweeper
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			const int ROW = 9;
			const int COL = 9;
			const int MINES_COUNT = 10;

			int[,] board = new int[ROW, COL]; //상수로
			int[,] mines;
			bool[,] boardFlag = new bool[ROW, COL];

			// 지뢰 생성, 지뢰배열값 출력
			mines = MakeMines(ROW, COL, MINES_COUNT);
			board = MakeMinesweeperBoard(ROW, COL, mines);

			PrintMinesForTest(mines);
			Console.WriteLine("----------------------------");
			PrintMinesweeperBoard(board);

			//// while문으로 play
			//while ()
			//{
			//	ShowBoard(board, board_bools);
			//	Console.Write("선택할 칸을 입력하시오(1 1 ~ 9 9): ");
			//	//int[,] inputCoordinate = GetInput()
			//	string input = Console.ReadLine();
			//	string[] str = input.Split(" ");
			//	int[] integers = new int[2];
			//	for (int i = 0; i < integers.Length; i++)
			//	{
			//		integers[i] = int.Parse(str[i]);
			//	}

			//	boardFlag[inputCoordinate[0], inputCoordinate[1]] = true;
			//	if (지뢰아니었다면)
			//	{
			//		//Traversal => 0인칸들 열리게(재귀이용)
			//	}
			//	else
			//	{
			//		Console.WriteLine("지뢰를 밟았습니다!\nGame Over!");
			//		break;
			//	}
			//}
		}

		private static int[,] MakeMines(int row, int col, int minesCount)
		{
			Random random = new Random();
			int[,] mine = new int[minesCount, 2];
			for (int i = 0; i < minesCount; i++)
			{
				mine[i, 0] = random.Next(9);
				mine[i, 1] = random.Next(9);
			}
			return mine;
		}

		private static int[,] MakeMinesweeperBoard(int row, int col, int[,] mines)
		{
			int[,] minesweeperBoard = new int[row, col];
			for (int i = 0; i < mines.GetLength(0); i++)
			{
				int x = mines[i, 0];
				int y = mines[i, 1];
				minesweeperBoard[x, y] = -1;
			}

			// 지뢰 주변에 숫자 배정
			for (int i = 0; i < minesweeperBoard.GetLength(0); i++)
			{
				for (int j = 0; j < minesweeperBoard.GetLength(1); j++)
				{
					for (int k = i - 1; k <= i + 1; k++)
					{
						for (int l = j - 1; l <= j + 1; l++)
						{
							int mineCount = 0;
							if (k < 0 || k >= 9 || l < 0 || l >= 9)
								continue;

							if (k == i && l == j)
								continue;
						}
					}
				}
			}
			return minesweeperBoard;
		}

		private static void PrintMinesForTest(int[,] mines)
		{
			for (int i = 0; i < mines.GetLength(0); i++)
			{
				Console.Write("{0}, {1}", mines[i, 0], mines[i, 1]);
				Console.WriteLine();
			}
		}

		private static void PrintMinesweeperBoard(int[,] board)
		{
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					Console.Write(" {0} ", board[i, j]);
				}
				Console.WriteLine();
			}
		}

		private static void ShowBoard(int[,] board, bool[,] board_bools)
		{
			for (int i = 0; i < board_bools.GetLength(0); i++)
			{
				for (int j = 0; j < board_bools.GetLength(1); j++)
				{
					if (board_bools[i, j] == true)
					{
						Console.WriteLine(" {0} ", board[i, j]);
					}
				}
			}
		}
	}
}
