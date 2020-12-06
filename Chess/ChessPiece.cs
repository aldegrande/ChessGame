/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 11/30/2020
 * Final Project
 * Chess Game
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace FinalProject.Chess
{
    //creates all the chess pieces for the board
	public abstract class ChessPiece 
	{
        public bool _isHuman { get; protected set; }
        //score that the piece is worth 
        public virtual int pieceValue { get { return 0; } }
        public virtual String name { get; protected set; }
        //coordinates of the chesspiece
        public int xPos { get; set; }
        public int yPos { get; set; }
       
        public virtual Image display { get;protected set; }
   
        //empty constuctor for copying
		
        //constructor for copying parameters
        
        public virtual bool isValidMove(BoardCell cell)
        {
            return false;
        }
        public virtual bool isBlocked(BoardCell cell)
        {
            bool blocked = false;
            if (cell.isOccupied)
            {
                for (int i = 0; i < StateOfPlay.activePieces.Count; i++)
                {
                    if (StateOfPlay.activePieces[i].xPos == cell.xAxis && StateOfPlay.activePieces[i].yPos == cell.yAxis)
                    {
                        if (StateOfPlay.activePieces[i]._isHuman == this._isHuman)
                        {
                            blocked = true;
                        }
                    }
                }
            }
            return blocked;
        }



    }

}
