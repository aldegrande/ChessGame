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
        public List<ChessPiece> playerPieces;
        public int playerScore { get; protected set; }
        //method to change coordinates of chess piece
        public int getPlayerScore(Player player)
        {
            int i = 0;
            while (i < player.playerPieces.Count)
            {
                if (StateOfPlay.activePieces[i]._isHuman)
                { 
                    this.playerScore += StateOfPlay.activePieces[i].pieceValue;
                }
                i++;
            }
            return playerScore;
        }


    }
}
