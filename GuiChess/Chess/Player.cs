/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 11/30/2020
 * Final Project
 * Chess Game
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Chess
{
	//class for player1(human) and Bobby(cpu) to read off of
	public abstract class Player
	{
		//if the human player is in control
		public bool isPlayerTurn { get; set; }
		
		public int score { get; set; }
		//method to change coordinates of chess piece
		public static void movePiece(ChessPiece piece, BoardCell cell)
        {
			
			piece.xPos = cell.xAxis;
			piece.yPos = cell.yAxis;
			cell.isOccupied = true;
		}

	}
}
