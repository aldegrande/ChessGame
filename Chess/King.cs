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
    class King : ChessPiece
    {

        public override String name { get { return "king"; } }
        public override int pieceValue { get { return 900; } }

        protected bool inCheck { get; set; }
       
        public King(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this.yPos = y;
            this.xPos = x;
            if (_isHuman)
            {

                this.display = Properties.Resources.black_king;

            }
            else
            {

                this.display = Properties.Resources.white_king;
            }
        }

        public override bool isValidMove(BoardCell cell)
        {
            return this.kingCheck(cell);
        }
        public bool kingCheck(BoardCell cell)
        {
            bool isValid = false;
            if (cell.xAxis >= this.xPos - 1 && cell.xAxis <= this.xPos + 1 && cell.yAxis >= this.yPos - 1 && cell.yAxis <= this.yPos + 1)
            {

                isValid = true;

            }
            return isValid;
        }

    }


}

