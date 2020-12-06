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
    //Class for the cpu chess player
    //No AI in use as of now. 
    public class Bobby : Player
    {
        public Bobby(int score)
        {
            this.playerScore = score;
        }
        public void setOfPieces()
        {
            int i = 0;
            while (i < playerPieces.Count)
            {
                if (!(StateOfPlay.activePieces[i]._isHuman))
                {
                    this.playerPieces.Add(StateOfPlay.activePieces[i]);
                }
                i++;
            }
        }
    }
}

