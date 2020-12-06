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
    class Bishop : ChessPiece
    {
        public override String name { get { return "bishop"; } }
        public override int pieceValue { get { return 50; } }

       
        public Bishop(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this.yPos = y;
            this.xPos = x;
            if (_isHuman)
            {

                this.display = Properties.Resources.black_bishop;

            }
            else
            {

                this.display = Properties.Resources.white_bishop;
            }
        }

        public override bool isValidMove(BoardCell cell)
        {
            return this.bishopCheck(cell);
        }
        public override bool isBlocked(BoardCell cell)
        {
            return this.isBishopBlocked(cell);
        }
        public bool bishopCheck(BoardCell cell)
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

            return isValid;
        }
        public bool isBishopBlocked(BoardCell cell)
        {
            bool bishopBlocked = false;
            int dirX = cell.xAxis > this.xPos ? 1 : -1;
            int dirY = cell.yAxis > this.yPos ? 1 : -1;
            for (int i = 0; i < (Math.Abs(cell.xAxis - this.xPos)); ++i)
            {
                if (this.xPos + (i * dirX) < ChessBoard.BoardSize && this.yPos + (i * dirY) < ChessBoard.BoardSize)
                {
                    if (StateOfPlay.gameBoard.board[this.xPos + (i * dirX), this.yPos + (i * dirY)].isOccupied)
                    {

                        bishopBlocked = true;
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
                            bishopBlocked = true;
                            break;
                        }
                    }
                }
            }
            return bishopBlocked;
        }
    }

}




