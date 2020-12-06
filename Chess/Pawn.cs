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
    class Pawn : ChessPiece
    {
        
        public override String name { get { return "pawn"; } }
        private bool _isFirstTurn { get; set; }
        public override int pieceValue { get { return 10; } }
        public Pawn(bool isHuman, int x, int y)
        {
            this._isHuman = isHuman;
            this._isFirstTurn = true;
            this.yPos = y;
            this.xPos = x;
            if (_isHuman)
            {

                this.display = Properties.Resources.black_pawn;

            }
            else
            {

                this.display = Properties.Resources.white_pawn;
            }
        }
        public bool isFIrstTurn
        {
            get
            {
                return this._isFirstTurn;
            }
            set
            {
                this._isFirstTurn = value;
            }
        }
        public override bool isValidMove(BoardCell cell)
        {
            return this.pawnCheck(cell);
        }
        //Checks if move accurate for pawn
        public bool pawnCheck(BoardCell cell)
        {
            bool isValid = false;
            //moveset for the players direction
            if (this._isHuman)
            {
                if (this.isFIrstTurn)
                {
                    if(cell.xAxis == this.xPos && this.yPos + 2 == cell.yAxis)
                    {
                        isValid = true;
                    }
                    else if(cell.xAxis == this.xPos && this.yPos + 1 == cell.yAxis){

                        isValid = true;
                    }else if (cell.isOccupied)
                    {
                        for (int x = 0; x < StateOfPlay.activePieces.Count; x++)
                        {
                            if(StateOfPlay.activePieces[x].xPos == cell.xAxis && StateOfPlay.activePieces[x].yPos == cell.yAxis)
                            {
                                if(!(StateOfPlay.activePieces[x]._isHuman))
                                {
                                    if((cell.xAxis == this.xPos + 1 || cell.xAxis == this.xPos - 1) && this.yPos + 1 == cell.yAxis)
                                    {
                                        isValid = true;
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            else 
            //movest for cpu direction
            {
                if (this.isFIrstTurn)
                {
                    if (cell.xAxis == this.xPos && this.yPos - 2 == cell.yAxis)
                    {
                        isValid = true;
                    }
                }
                else if (cell.xAxis == this.xPos && this.yPos - 1 == cell.yAxis)
                {

                    isValid = true;
                }
                //checks if cell has friendly pieve in the way
                else if (cell.isOccupied)
                {
                    for (int x = 0; x < StateOfPlay.activePieces.Count; x++)
                    {
                        if (StateOfPlay.activePieces[x].xPos == cell.xAxis && StateOfPlay.activePieces[x].yPos == cell.yAxis)
                        {
                            if (StateOfPlay.activePieces[x]._isHuman)
                            {
                                if ((cell.xAxis == this.xPos + 1 || cell.xAxis == this.xPos - 1) && this.yPos - 1 == cell.yAxis)
                                {
                                    isValid = true;
                                }
                            }
                        }
                    }
                }
            }
            return isValid;
        }
            
        }


    }

