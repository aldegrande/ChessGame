/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 11/30/2020
 * Final Project
 * Chess Game
 */
using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Chess;

namespace GuiChess
{
    //abstract class that has the method to make changes and validate moves on the board

	public abstract class StateOfPlay 
	{
        //the list of chess pieces active in the game
        public static List<ChessPiece> activePieces = new List<ChessPiece>();
        //the gameboard
        public static ChessBoard gameBoard = new ChessBoard();
        //keeps the gamescore
        public static int gameScore { get; set; }

        //sets the gamescore
        public static void setGameScore()
        {
            for(int i = 0; i < activePieces.Count; i++)
            {
                gameScore += activePieces[i].score;
            }
        }
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
        public static bool checkLane(ChessPiece piece, BoardCell boardcell)
        {
            bool laneCheck = true;
            int cellX = boardcell.xAxis;
            int cellY = boardcell.yAxis;
            int pieceX = piece.xPos;
            int pieceY = piece.yPos;

            if (pieceX == cellX)
            {
                if(pieceY < cellY)
                {
                    for(int i = pieceY+1; i < cellY; i++)
                    {
                        if (gameBoard.board[cellX, i].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if(pieceY > cellY)
                {
                    for (int i = pieceY-1; i > cellY; i--)
                    {
                        if (gameBoard.board[cellX, i].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
            }else if(pieceY == cellY)
            {
                if (pieceX < cellX)
                {
                    for (int i = pieceX+1; i < cellX; i++)
                    {
                        if (gameBoard.board[i, cellY].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if (pieceX > cellX)
                {
                    for (int i = pieceY-1; i > cellY; i--)
                    {
                        if (gameBoard.board[i, cellY].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if (pieceX > cellX && pieceY < cellY)
                {
                    for(int i = pieceX - 1,j = pieceY + 1; i < cellX || j > cellY; i--, j++)
                    {
                        if(gameBoard.board[i, j].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if (pieceX > cellX && pieceY < cellY)
                {
                    for (int j = pieceY - 1, i = pieceX + 1; j < cellY || i > cellX; j--, i++)
                    {
                        if (gameBoard.board[i, j].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if (pieceX > cellX && pieceY > cellY)
                {
                    for (int j = pieceY - 1, i = pieceX - 1; j > cellY || i > cellX; j--, i--)
                    {
                        if (gameBoard.board[i, j].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
                else if (pieceX < cellX && pieceY < cellY)
                {
                    for (int j = pieceY + 1, i = pieceX + 1; j < cellY || i < cellX; j++, i++)
                    {
                        if (gameBoard.board[i, j].isOccupied)
                        {
                            laneCheck = false;
                        }
                    }
                }
            }
            return laneCheck;
        }
        //Validates move based on the chess piece or if cell is occupied by other player
        public static bool isValidMove(ChessPiece piece, BoardCell boardcell)
        {
            
            
            bool isValid = false;
            switch (piece.type)
            {
                case "pawn":
                    
               
                        if(boardcell.xAxis == piece.xPos && piece.yPos + 1 == boardcell.yAxis && piece.team == "player")
                        {
                            isValid = true;
                        }else if(boardcell.xAxis == piece.xPos && piece.yPos - 1 == boardcell.yAxis && piece.team == "cpu")
                        {
                            isValid = true;
                        }
                    
                    break;
                case "rook":
                    
                        if (boardcell.yAxis == piece.yPos || piece.xPos == boardcell.xAxis)
                        {
                            if (checkLane(piece, boardcell))
                            {
                                isValid = true;
                            }
                        }
                    
                    break;
                case "bishop":
                    
                        if (boardcell.xAxis - piece.xPos == boardcell.yAxis - piece.yPos)  
                        {
                            isValid = true;
                        }else if(piece.xPos - boardcell.xAxis == piece.yPos - boardcell.yAxis)
                        {
                            isValid = true;
                        }
                        else if(piece.yPos - boardcell.yAxis == boardcell.xAxis - piece.xPos)
                        {
                            isValid = true;
                        }
                        else if (piece.xPos - boardcell.xAxis == boardcell.yAxis - piece.yPos)
                        {
                            isValid = true;
                        }
                        if (!(checkLane(piece, boardcell)))
                        {
                            isValid = false;
                        }
                    
                    break;
                case "knight":
                    
                        if (boardcell.yAxis == piece.yPos + 1 && piece.xPos + 2 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if(boardcell.yAxis == piece.yPos - 1 && piece.xPos + 2 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos - 1 && piece.xPos - 2 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos + 1 && piece.xPos - 2 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos - 2 && piece.xPos + 1 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos - 2 && piece.xPos - 1 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos + 2 && piece.xPos - 1 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos + 2 && piece.xPos + 1 == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                    
                    break;
                case "queen":
                    
                        if (boardcell.xAxis - piece.xPos == boardcell.yAxis - piece.yPos)
                        {
                            isValid = true;
                        }
                        else if (piece.xPos - boardcell.xAxis == piece.yPos - boardcell.yAxis)
                        {
                            isValid = true;
                        }
                        else if (piece.yPos - boardcell.yAxis == boardcell.xAxis - piece.xPos)
                        {
                            isValid = true;
                        }
                        else if (piece.xPos - boardcell.xAxis == boardcell.yAxis - piece.yPos)
                        {
                            isValid = true;
                        }
                        else if (boardcell.yAxis == piece.yPos || piece.xPos == boardcell.xAxis)
                        {
                            isValid = true;
                        }
                        if (!(checkLane(piece, boardcell)))
                        {
                            isValid = false;
                        }
                    
                    break;
                case "king":
                    
                        if (boardcell.xAxis >= piece.xPos - 1 && boardcell.xAxis <= piece.xPos + 1 && boardcell.yAxis >= piece.yPos - 1 && boardcell.yAxis <= piece.yPos + 1)
                        {
                            
                            isValid = true;
                     
                        }
                    
                    break;
            }
            if (boardcell.isOccupied && isValid)
            {
                for(int i = 0; i < StateOfPlay.activePieces.Count; i++)
                {
                    if(StateOfPlay.activePieces[i].xPos == boardcell.xAxis && StateOfPlay.activePieces[i].yPos == boardcell.yAxis)
                    {
                        if(StateOfPlay.activePieces[i].team != piece.team)
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }
            }
            return isValid;
        }
        
	}
}
