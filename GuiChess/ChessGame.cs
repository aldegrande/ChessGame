/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 12/5/20
 * Final Project Version 2
 * Chess Game
 */
using FinalProject.Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiChess
{
    //Chessgame class that runs the GUI for the game
    public partial class ChessGame : Form
    {
        //Creates a grid of buttons to represent the chess board graphically
        public static Button[,] guiGrid = new Button[ChessBoard.BoardSize, ChessBoard.BoardSize];
        //Creates a new player object that the user controls with the starting score
        public Player1 player = new Player1(1220);
        //creates a new cpu AI
        public Bobby cpu = new Bobby(1220);
        //Initializes a chess piece to be used in comparisons 
        protected ChessPiece piece;
      
        //fields for tracking the last position of a piece
        protected int prevX;
        protected int prevY;

        //Constructor calls renderboard
        public ChessGame()
        {
            
            InitializeComponent();
            renderBoard();
            
            startButton.MouseClick += StartButton_MouseClick;
               

        }
        
        //Click event method that sets the board and displays intro message
        private void StartButton_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;

            //loops through each piece and puts them on the board
            StateOfPlay.setPieces();
            fillBoard(StateOfPlay.activePieces);
            //Displays gamescore in the textbox
            setScore();
            //Removes the click event on start button
            startButton.MouseClick -= StartButton_MouseClick;
               //Displays intro message
            MessageBox.Show("Welcome to my chess appliaction.\nClick your piece then a valid spot to see valid moves.\nValid moves are indicated by the color green. Invalid by red", "Chess Sim App");
            for (int i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (int j = 0; j < ChessBoard.BoardSize; j++)
                {
                    guiGrid[i, j].Click += Board_Button_Click;
                }
            }

        }

        //creates the graphical interpretation of the chessboard
        private void renderBoard()
        {
            int buttonSize = panel1.Width / ChessBoard.BoardSize;
            panel1.Height = panel1.Width;

            for (int i = 0; i < ChessBoard.BoardSize; i++)
            {

                for (int j = 0; j < ChessBoard.BoardSize; j++)
                {
                    guiGrid[i, j] = new Button();
                    guiGrid[i, j].Height = buttonSize;
                    guiGrid[i, j].Width = buttonSize;
                    if ((i + j) % 2 == 1)
                    {
                        guiGrid[i, j].BackColor = Color.DarkGray;
                    }
                    else
                    {
                        guiGrid[i, j].BackColor = Color.White;
                    }
                    guiGrid[i, j].Tag = new Point(i, j);
                    panel1.Controls.Add(guiGrid[i, j]);
                    guiGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    
                    guiGrid[i, j].Text = i + "," + j;

                }
            }
        }
        public void setScore()
        {
            scoreBox1.Text = "Score: " + player.playerScore;
            scoreBox2.Text = "Score: " + cpu.playerScore;
        }
        //sets up images on the game board and sets occupied cells status
        public static void fillBoard(List<ChessPiece> pieces)
        {
            int p; 
            for (int i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (int j = 0; j < ChessBoard.BoardSize; j++)
                {
                    p = 0;
                    while (p < pieces.Count)
                    {
                        if (i == pieces[p].xPos && j == pieces[p].yPos)
                        {
                            guiGrid[i, j].BackgroundImage = pieces[p].display;
                            guiGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            StateOfPlay.gameBoard.board[i, j].isOccupied = true;

                        }
                        p++;
                    }
                }
            }
        }
        // event that selects a piece for the user. First click for user
        private void Board_Button_Click(object sender, EventArgs e)
        {
            
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            
           
            int x = location.X;
            int y = location.Y;
            for (int z = 0; z < StateOfPlay.activePieces.Count; z++)
            {
                if (StateOfPlay.activePieces[z].yPos == y && StateOfPlay.activePieces[z].xPos == x)
                {
                    if (StateOfPlay.activePieces[z]._isHuman)
                    {
                        checkMoves(StateOfPlay.activePieces[z]);
                        prevX = StateOfPlay.activePieces[z].xPos;
                        prevY = StateOfPlay.activePieces[z].yPos;
                        for (int i = 0; i < ChessBoard.BoardSize; i++)
                        {
                            for (int j = 0; j < ChessBoard.BoardSize; j++)
                            {
                                guiGrid[i, j].MouseMove += Form1_MouseMove;
                                guiGrid[i, j].Click += Next_Click;
                                guiGrid[i, j].MouseLeave += Form1_MouseLeave;
                                

                            }

                        }
                        
                    }

                }
            }
        }
        //sets the board cells to valid or invalid based on piece selected
        public void checkMoves(ChessPiece selectedPiece)
        {
            for (int i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (int j = 0; j < ChessBoard.BoardSize; j++)
                {
                    if (selectedPiece.isValidMove(StateOfPlay.gameBoard.board[i, j]))
                    {
                        if (!(selectedPiece.isBlocked(StateOfPlay.gameBoard.board[i, j])))
                        {
                        
                        
                            StateOfPlay.gameBoard.board[i, j].isValid = true;
                        }      
                    }
                    else
                    {
                        StateOfPlay.gameBoard.board[i, j].isValid = false;
                    }
                }
            }
        }
        //Highlights cells that are valid moves green and invalid red
        private void Form1_MouseMove(object sender, EventArgs e)
        {
            Button hoveredButton = (Button)sender;
            Point location = (Point)hoveredButton.Tag;
            int x = location.X;
            int y = location.Y;

            if (StateOfPlay.gameBoard.board[x, y].isValid)
            {
                    guiGrid[x, y].BackColor = Color.Green;
             
            }
            else
            {
                    guiGrid[x, y].BackColor = Color.Red;
                  
            }
        }
        //Click event for after player click on a piece. The second click.
        private void Next_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int x = location.X;
            int y = location.Y;
            if (StateOfPlay.gameBoard.board[x, y].isValid)
            {
                
                for (int i = 0; i < ChessBoard.BoardSize; i++)
                {
                    for (int j = 0; j < ChessBoard.BoardSize; j++)
                    {
                        guiGrid[i, j].Click -= Next_Click;
                        guiGrid[i, j].Click -= Form1_MouseLeave;
                        guiGrid[i, j].Click -= Form1_MouseMove;
                       
                    }
                }
                playerMovePiece(location.X, location.Y, player);
                
            }
          
         
        }
        //Moves player piece
        private void playerMovePiece(int x, int y, Player player)
        {
            //finds the piece to mov by matching coordinates with parameters and changes the coordinates to new position on board
            for (int i = 0; i < StateOfPlay.activePieces.Count; i++)
            {
                if (StateOfPlay.activePieces[i].yPos == prevY && StateOfPlay.activePieces[i].xPos == prevX)
                {
                    StateOfPlay.gameBoard.board[prevX, prevY].isOccupied = false;
                    StateOfPlay.activePieces[i].xPos = x;
                    StateOfPlay.activePieces[i].yPos = y;

                    guiGrid[prevX, prevY].BackgroundImage = null;

                    guiGrid[x, y].BackgroundImage = StateOfPlay.activePieces[i].display;
                    guiGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    StateOfPlay.gameBoard.board[x, y].isOccupied = true;
                }
            }


        }
        

        //sets colors back to normal after mouse leaves the cell
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Button hoveredButton = (Button)sender;
            Point location = (Point)hoveredButton.Tag;
            int x = location.X;
            int y = location.Y;
            if ((x + y) % 2 == 1)
            {
                guiGrid[x, y].BackColor = Color.DarkGray;
            }
            else
            {
                guiGrid[x, y].BackColor = Color.White;
            }
        }
     
        
        
    }
}
