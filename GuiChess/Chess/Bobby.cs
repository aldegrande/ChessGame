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
    //Class for the cpu chess player
    public class Bobby : Player
    {
        public Bobby()
        {
            //initiates the Ai Chess pieces
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(0, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(1, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(2, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(3, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(4, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(5, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(6, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(7, 6, "cpu", "pawn"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(0, 7, "cpu", "rook"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(7, 7, "cpu", "rook"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(6, 7, "cpu", "knight"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(1, 7, "cpu", "knight"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(5, 7, "cpu", "bishop"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(2, 7, "cpu", "bishop"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(3, 7, "cpu", "queen"));
            GuiChess.StateOfPlay.activePieces.Add(new ChessPiece(4, 7, "cpu", "king"));
            for (int i = 0; i < GuiChess.StateOfPlay.activePieces.Count; i++)
            {
                this.score += GuiChess.StateOfPlay.activePieces[i].score;
            }
        }
        public ChessPiece makeMove()
        {
            ChessPiece copyPiece = new ChessPiece();

            for (int j = 0; j < ChessBoard.BoardSize; j++)
            {
                for (int k = 0; k < ChessBoard.BoardSize; k++)
                {
                    if (GuiChess.StateOfPlay.activePieces[j + k].team == "cpu")
                    {
                        for (int x = 0; x < ChessBoard.BoardSize; x++)
                        {
                            for (int y = 0; y < ChessBoard.BoardSize; y++)
                            {
                                if (GuiChess.StateOfPlay.isValidMove(GuiChess.StateOfPlay.activePieces[j + k], GuiChess.StateOfPlay.gameBoard.board[x, y]))
                                {
                                    GuiChess.StateOfPlay.activePieces[j + k].xPos = x;
                                    GuiChess.StateOfPlay.activePieces[j + k].yPos = y;
                                    copyPiece = GuiChess.StateOfPlay.activePieces[j + k];
                                    j = ChessBoard.BoardSize;
                                    k = ChessBoard.BoardSize;
                                }
                            }
                        }
                    }

                }
                
            }
            return copyPiece;
        }
    }
}

