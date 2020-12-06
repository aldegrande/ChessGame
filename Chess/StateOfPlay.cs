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
    //abstract class that has the method to make changes and validate moves on the board

	public abstract class StateOfPlay 
	{
		public static bool gameOver = false;
        //the list of chess pieces active in the game
        public static List<ChessPiece> activePieces = new List<ChessPiece>();
		//the gameboard
		public static ChessBoard gameBoard = new ChessBoard();
		//keeps the gamescore
		public static int gameScore { get; set; }

        //sets the gamescore
       
        //removes the opponents chess piece if piece is taken
        public static void takePiece(ChessPiece takenPiece)
        {
            for (int i = 0; i < activePieces.Count; i++)
            {
                if (takenPiece.xPos == activePieces[i].xPos && takenPiece.yPos == activePieces[i].yPos)
                {

                    activePieces.RemoveAt(i);
                }
            }
        }
		//checks to see if the path is clear of obstacles. 

		public static int findPieceIndex(int xPos, int yPos) 
        {
            ChessPiece newpiece = null;
			int pieceIndex = 0;
			for (int i = 0; i < activePieces.Count; i++)
			{
				if (activePieces[i].xPos == xPos && activePieces[i].yPos == yPos)
				{
					newpiece = activePieces[i];
					pieceIndex = i;
					break;
				}
				
			}
			return pieceIndex;
		}
		public static void setPieces()
        {
			for (int i = 0; i < 8; i++)
			{
				activePieces.Add(new Pawn(true, i, 1));
				activePieces.Add(new Pawn(false, i, 6));
				
			}
			activePieces.Add(new Rook(true, 0, 0));
			activePieces.Add(new Rook(true, 7, 0));
			activePieces.Add(new Rook(false, 0, 7));
			activePieces.Add(new Rook(false, 7, 7));
			activePieces.Add(new Bishop(true, 2, 0));
			activePieces.Add(new Bishop(true, 5, 0));
			activePieces.Add(new Bishop(false, 2, 7));
			activePieces.Add(new Bishop(false, 5, 7));
			activePieces.Add(new Knight(true, 1, 0));
			activePieces.Add(new Knight(true, 6, 0));
			activePieces.Add(new Knight(false, 1, 7));
			activePieces.Add(new Knight(false, 6, 7));
			activePieces.Add(new Queen(true, 3, 0));
			activePieces.Add(new Queen(false, 3, 7));
			activePieces.Add(new King(true, 4, 0));
			activePieces.Add(new King(false, 4, 7));
		}

	}

}

