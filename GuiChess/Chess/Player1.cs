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
	public class Player1 : Player
	{

        //Creates the ChessPieces for the Player1(human)
        public Player1()
        {
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(0, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(1, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(2, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(3, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(4, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(5, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(6, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(7, 1, "player", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(0, 0, "player", "rook"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(7, 0, "player", "rook"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(6, 0, "player", "knight"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(1, 0, "player", "knight"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(5, 0, "player", "bishop"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(2, 0, "player", "bishop"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(3, 0, "player", "queen"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(4, 0, "player", "king"));

            for (int i = 0; i < GuiChess.StateOfPlay.activePieces.Count; i++)
            {
                this.score += GuiChess.StateOfPlay.activePieces[i].score;
            }
        }
	}
}
