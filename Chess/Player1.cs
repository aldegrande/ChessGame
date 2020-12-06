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
        public Player1(int score)
        {
            this.playerScore = score;
        }
        public void setOfPieces()
        {
            int i = 0;
            while (i < playerPieces.Count)
            {
                if (StateOfPlay.activePieces[i]._isHuman)
                {
                    this.playerPieces.Add(StateOfPlay.activePieces[i]);
                }
                i++;
            }
        }
        
    }
}
