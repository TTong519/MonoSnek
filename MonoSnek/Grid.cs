using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoSnek
{
    public class Grid
    {
        public Rectangle[,] Squares = new Rectangle[10, 10];

        public int GridWidth => Squares.GetLength(0);
        public int GridHeight => Squares.GetLength(1);
        public int Size;

        public Grid(int size)
        {
            Size = size;
            for (int i = 0; i < GridWidth; i++)
            {
                for (int j = 0; j < GridHeight; j++)
                {
                    Squares[i, j] = new(GridWidth + Size * j, GridHeight + Size * i, Size, Size);
                }
            }
        }
    }
}