/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 12/5/20
 * Final Project Version 2
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
    class Rook : ChessPiece
    {
        public override String name { get { return "rook"; } }
        public override int pieceValue { get { return 30; } }

        public Rook(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this.yPos = y;
            this.xPos = x;
            if (_isHuman)
            {

                this.display = Properties.Resources.black_rook;

            }
            else
            {

                this.display = Properties.Resources.white_rook;
            }
        }

        public override bool isValidMove(BoardCell cell)
        {
            return this.rookCheck(cell);
        }
        public bool rookCheck(BoardCell cell)
        {
            bool isValid = false;
            if (cell.yAxis == this.yPos || this.xPos == cell.xAxis)
            {
                isValid = true;

            }
                return isValid;
        }
        public override bool isBlocked(BoardCell cell)
        {
            return this.isRookBlocked(cell);
        }
        //Not working correctly as of now. Check for bishop path
        public bool isRookBlocked(BoardCell cell)
        {
            bool rookBlocked = false;
            int dirX = 0;
            int dirY = 0;
           if(cell.xAxis != this.xPos)
            {
                dirX = cell.xAxis > this.xPos ? 1 : -1;
            }
            else
            {
                dirY = cell.yAxis > this.yPos ? 1 : -1;
            }
        
            for (int i = 0; i < (Math.Abs(cell.xAxis - this.xPos)); ++i)
            {
                if (this.xPos + (i * dirX) < ChessBoard.BoardSize && this.yPos + (i * dirY) < ChessBoard.BoardSize)
                {
                    if (StateOfPlay.gameBoard.board[this.xPos + (i * dirX), this.yPos + (i * dirY)].isOccupied)
                    {

                        rookBlocked = true;
                        break;
                    }
                }
            }
            return rookBlocked;
        }

     }


}

