/*@Author: Alex DeGrande
 * Class: CS 260
 * Date: 11/30/2020
 * Final Project
 * Chess Game
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Chess
{
	//Represents one square on the chess board
	public class BoardCell
	{
		public bool isOccupied;
		public int xAxis;
		public int yAxis;
		

		public BoardCell(int x, int y)
        {
			this.xAxis = x;
			this.yAxis = y;
			this.isOccupied = false;
			
        }
	}
}
