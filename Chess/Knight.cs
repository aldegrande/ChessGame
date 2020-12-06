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
    class Knight : ChessPiece
    {
        public override String name { get { return "knight"; } }
        public override int pieceValue { get { return 30; } }

        
        public Knight(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this.yPos = y;
            this.xPos = x;
            if (_isHuman)
            {

                this.display = Properties.Resources.black_knight;

            }
            else
            {

                this.display = Properties.Resources.white_knight;
            }
        }

        public override bool isValidMove(BoardCell cell)
        {
            return this.knightCheck(cell);
        }
        public bool knightCheck(BoardCell cell)
        {
            bool isValid = false;
            if (cell.yAxis == this.yPos + 1 && this.xPos + 2 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos - 1 && this.xPos + 2 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos - 1 && this.xPos - 2 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos + 1 && this.xPos - 2 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos - 2 && this.xPos + 1 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos - 2 && this.xPos - 1 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos + 2 && this.xPos - 1 == cell.xAxis)
            {
                isValid = true;
            }
            else if (cell.yAxis == this.yPos + 2 && this.xPos + 1 == cell.xAxis)
            {
                isValid = true;
            }
            return isValid;
        }

    }


}

