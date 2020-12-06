/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 12/5/20
 * Final Project Version 2
 * Chess Game
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Chess
{
	//board that sets the dimensions and creates the BoadrCells for the game
	public class ChessBoard
	{
		public const int BoardSize = 8;
		public BoardCell[,] board { get; private set; }
		
		public ChessBoard()
		{
			board = new BoardCell[BoardSize, BoardSize];

			for (int i = 0; i < BoardSize; i++)
			{
				for (int j = 0; j < BoardSize; j++)
				{
					board[i, j] = new BoardCell(i, j);
				}
			}
		}
	}
}
