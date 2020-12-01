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
using GuiChess;

namespace FinalProject.Chess
{
    //creates all the chess pieces for the board
	public class ChessPiece 
	{
        //score that the piece is worth
        public int score { get; set; }
        //coordinates of the chesspiece
		public int xPos { get; set; }
        public int yPos { get; set; }
        //if the piece is human or not
		public String team { get; private set; }
        //what kind of piece it is
		public String type { get; set; }
        //the display for the piece
        public Image display;
   
        //empty constuctor for copying
		public ChessPiece()
        {
            this.score = 0;
            this.xPos = 0;
            this.yPos = 0;
            this.team = "player";
            this.type = "pawn";
            this.display = null;
        }
        //main constructor used
		public ChessPiece(int x, int y, String side, String type)
        {
    
            this.xPos = x;
            this.yPos = y;
            this.team = side;
            this.type = type;

               //switch statement to set the type of piece, score, and image
            switch (type)
            {
                case "pawn":

                    if (side == "player")
                    {
                        this.score = 10;
                        this.display = Properties.Resources.black_pawn;
       
                    }
                    else
                    {
                        this.score = -10;
                        this.display = Properties.Resources.white_pawn;
                    }
                    break;
                case "rook":
                    
                    if (side == "player")
                    {
                        this.score = 50;
                        this.display = Properties.Resources.black_rook;
                    }
                    else
                    {
                        this.score = -50;
                        this.display = Properties.Resources.white_rook;
                    }
                    break;
                case "bishop":
                    
                    if (side == "player")
                    {
                        this.score = 30;
                        this.display = Properties.Resources.black_bishop;
                    }
                    else
                    {
                        this.display = Properties.Resources.white_bishop;
                        this.score = -30;
                    }
                    break;
                case "knight":
                    
                    if (side == "player")
                    {
                        this.score = 30;
                        this.display = Properties.Resources.black_knight;
                    }
                    else
                    {
                        this.score = -30;
                        this.display = Properties.Resources.white_knight;
                    }
                    break;
                case "queen":
                    
                    if (side == "player")
                    {
                        this.score = 90;
                        this.display = Properties.Resources.black_queen;
                    }
                    else
                    {
                        this.score = -90;
                        this.display = Properties.Resources.white_queen;
                    }
                    break;
                case "king":
                    this.score = 900;
                    if (side == "player")
                    {
                        this.display = Properties.Resources.black_king;
                    }
                    else
                    {
                        this.score = -900;
                        this.display = Properties.Resources.white_king;
                    }
                    break;
            }
            
        }
        //constructor for copying parameters
        public ChessPiece(ChessPiece thePiece)
        {
           
            this.xPos = thePiece.xPos;
            this.yPos = thePiece.yPos;
            this.team = thePiece.team;
            this.score = thePiece.score;
            this.type = thePiece.type;
            this.display = thePiece.display;
        }


	}

}
