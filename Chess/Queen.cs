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
    class Queen : ChessPiece
    {
        public override String name { get { return "queen"; } }
        public override int pieceValue { get { return 100; } }

       
        public Queen(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this.yPos = y;
            this.xPos = x;
            if(_isHuman)
                {

                this.display = Properties.Resources.black_queen;

            }
                else
            {

                this.display = Properties.Resources.white_queen;
            }
        }

        public override bool isValidMove(BoardCell cell)
        {
            return this.queenCheck(cell);
        }
        public bool queenCheck(BoardCell cell)
        {
            bool isValid = false;
            if (cell.xAxis - this.xPos == cell.yAxis - this.yPos)
            {
                isValid = true;
            }
            else if (this.xPos - cell.xAxis == this.yPos - cell.yAxis)
            {
                isValid = true;
            }
            else if (this.yPos - cell.yAxis == cell.xAxis - this.xPos)
            {
                isValid = true;
            }
            else if (this.xPos - cell.xAxis == cell.yAxis - this.yPos)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos || this.xPos == cell.xAxis)
            {
                isValid = true;
            }
            
            return isValid;
        }
        public override bool isBlocked(BoardCell cell)
        {
            return this.isQueenBlocked(cell);
        }
        public bool isQueenBlocked(BoardCell cell)
        {
            bool queenBlocked = false;
            int dirX = cell.xAxis > this.xPos ? 1 : -1;
            int dirY = cell.yAxis > this.yPos ? 1 : -1;
            for (int i = 0; i < (Math.Abs(cell.xAxis - this.xPos)); ++i)
            {
                if (this.xPos + (i * dirX) < ChessBoard.BoardSize && this.yPos + (i * dirY) < ChessBoard.BoardSize)
                {
                    if (StateOfPlay.gameBoard.board[this.xPos + (i * dirX), this.yPos + (i * dirY)].isOccupied)
                    {

                        queenBlocked = true;
                        break;
                    }
                }
            }
            if (cell.isOccupied)
            {
                for (int i = 0; i < StateOfPlay.activePieces.Count; i++)
                {
                    if (StateOfPlay.activePieces[i].xPos == cell.xAxis && StateOfPlay.activePieces[i].yPos == cell.yAxis)
                    {
                        if (StateOfPlay.activePieces[i]._isHuman == this._isHuman)
                        {
                            queenBlocked = true;
                        }
                    }
                }
            }
            return queenBlocked;
        }
    }


}

