/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 11/30/2020
 * Final Project
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
    public partial class ChessGame : Form
    {
        //Creates a grid of buttons to represent the chess board graphically
        public Button[,] guiGrid = new Button[ChessBoard.BoardSize, ChessBoard.BoardSize];
        //Creates a new player object that the user controls
        public Player1 player = new Player1();
        //creates a new cpu AI
        public Bobby cpu = new Bobby();
        //Initializes a chess piece to be use in 
        public ChessPiece piece;

        //Chessgame class that runs the GUI for the game
        public ChessGame()
        {
            
                InitializeComponent();
                renderBoard();
                StateOfPlay.setGameScore();
            

            startButton.MouseClick += StartButton_MouseClick;

        }
        
        //Click event method that sets the board and displays intro message
        private void StartButton_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;

            //Start off as Players turn
            player.isPlayerTurn = true;
            
            //loops through each piece and puts them on the board
            for (int i = 0; i < StateOfPlay.activePieces.Count; i++)
            {
                fillBoard(StateOfPlay.activePieces[i]);
              
            }
            //Displays gamescore in the textbox
            scoreBox1.Text = "Score: " + StateOfPlay.gameScore;
            
            //Removes the click event on start button
            startButton.MouseClick -= StartButton_MouseClick;
               //Displays intro message
            MessageBox.Show("Welcome to my chess appliaction.\nClick your piece then a valid spot to see valid moves.\nValid moves are indicated by the color green. Invalid by red", "Chess Sim App");
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
                    guiGrid[i, j].Click += Board_Button_Click;
                    guiGrid[i, j].Text = i + "," + j;

                }
            }
        }
        //sets up images on the game board
        private void fillBoard(ChessPiece pieces)
        {
         
            for (int i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (int j = 0; j < ChessBoard.BoardSize; j++)
                {
                    if(i == pieces.xPos && j == pieces.yPos)
                    {
                        guiGrid[i, j].BackgroundImage = pieces.display;
                        guiGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        StateOfPlay.gameBoard.board[i, j].isOccupied = true;
                        
                    }
                }
            }
        }
        //Runs CPU turn. Inactive at the moment
        private void runCpuTurn()
        {
            piece = new ChessPiece(cpu.makeMove());
            playerMovePiece(piece, piece.xPos, piece.xPos, cpu);
            player.isPlayerTurn = true;
        }
        //Moves player piece
        private void playerMovePiece(ChessPiece piece, int x, int y, Player player)
        {
            //finds the piece to mov by matching coordinates with parameters and changes the coordinates to new position on board
            for(int i = 0; i < StateOfPlay.activePieces.Count; i++)
            {
                if(StateOfPlay.activePieces[i].yPos == piece.yPos && StateOfPlay.activePieces[i].xPos == piece.xPos)
                {
                    StateOfPlay.activePieces[i].xPos = x;
                    StateOfPlay.activePieces[i].yPos = y;
                }
            }
            //changes occupied value for previous cell to false and removes the image
            StateOfPlay.gameBoard.board[piece.xPos, piece.yPos].isOccupied = false;
            guiGrid[piece.xPos, piece.yPos].BackgroundImage = null;
            //sets new button location to the pieces image and sets the new cell to occupied
            guiGrid[x, y].BackgroundImage = piece.display;
            guiGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
            StateOfPlay.gameBoard.board[x, y].isOccupied = true;
        }
        //Button click event that started 
        private void Board_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            if (player.isPlayerTurn)
            {
                //get coordinates of button pushed
                int x = location.X;
                int y = location.Y;
                if (StateOfPlay.gameBoard.board[x, y].isOccupied)
                {
                    //traverse the pieces to find the selected piece by matching coordinates
                    for(int j = 0; j < ChessBoard.BoardSize; j++)
                    {
                        for(int k = 0; k < ChessBoard.BoardSize; k++)
                        {
                            if (StateOfPlay.activePieces[j+k].team == "player" && StateOfPlay.activePieces[j+k].xPos == x && StateOfPlay.activePieces[j+k].yPos == y)
                            {
                                //copies piece to use in the move method
                                piece = new ChessPiece(StateOfPlay.activePieces[j + k]);

                                //traverse through all cells on the board
                                for (int i = 0; i < ChessBoard.BoardSize; i++)
                                {
                                    for (int z = 0; z < ChessBoard.BoardSize; z++)
                                    {
                                        //add events 
                                        guiGrid[i, z].MouseMove += Form1_MouseMove;
                                        guiGrid[i, z].Click += ChessGame_Click;
                                        guiGrid[i, z].MouseLeave += Form1_MouseLeave;
                                       

                                    }
                                }
                            }
                        }
                    }
                   
                }

            }

        }
        //Click event that occurs after the player clicks on a piece
        private void ChessGame_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            
            //check validity of move
                    if (StateOfPlay.isValidMove(piece, StateOfPlay.gameBoard.board[location.X, location.Y]))
                    {
                //use move method
                        playerMovePiece(piece, location.X, location.Y, player);
                        for(int j = 0; j < StateOfPlay.activePieces.Count; j++)
                        {
                            if (StateOfPlay.activePieces[j].xPos == location.X && StateOfPlay.activePieces[j].yPos == location.Y)
                            {

                                StateOfPlay.takePiece(StateOfPlay.activePieces[j]);

                            }
                        }
                        //traverse cells and remove second level click events and add initial click event
                for (int i = 0; i < ChessBoard.BoardSize; i++)
                {
                    for (int z = 0; z < ChessBoard.BoardSize; z++)
                    {
                        StateOfPlay.gameBoard.board[i, z].isOccupied = true;
                        guiGrid[i, z].MouseMove -= Form1_MouseMove;
                        guiGrid[i, z].Click -= ChessGame_Click;
                        guiGrid[i, z].MouseLeave -= Form1_MouseLeave;
                        guiGrid[i, z].Click += Board_Button_Click;
                        player.isPlayerTurn = true;
                       //runCpuTurn();
                    }
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
        //sets color to green for valid move and red for invalid
        private void Form1_MouseMove(object sender, EventArgs e)
        {
            Button hoveredButton = (Button)sender;
            Point location = (Point)hoveredButton.Tag;
            if (player.isPlayerTurn)
            {
                if (StateOfPlay.isValidMove(piece, StateOfPlay.gameBoard.board[location.X, location.Y]))
                {

                    hoveredButton.BackColor = Color.Green;
                }
                else
                {
                    hoveredButton.BackColor = Color.Red;
                }
            }
        }
        
    }
}
