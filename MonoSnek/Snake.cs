using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoSnek
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Snake
    {
        public DoublyLinkedList<Point> Body;
        public Direction Dir;
        private Texture2D head;
        private Texture2D body;
        private Grid grid;
        public Snake(Point initpos, Texture2D head, Texture2D body, Grid grid, Direction initdir = Direction.Up)
        {
            Body = new DoublyLinkedList<Point>(initpos, new(initpos.X-1, initpos.Y));
            Dir = initdir;
            this.head = head;
            this.body = body;
            this.grid = grid;
        }
        public void Move()
        {
            Body.RemoveLast();
            switch(Dir)
            {
                case Direction.Up:
                    Body.AddFirst(new(Body.head.Value.X, Body.head.Value.Y - 1));
                    break;
                case Direction.Down:
                    Body.AddFirst(new(Body.head.Value.X, Body.head.Value.Y + 1));
                    break;
                case Direction.Left:
                    Body.AddFirst(new(Body.head.Value.X - 1, Body.head.Value.Y));
                    break;
                case Direction.Right:
                    Body.AddFirst(new(Body.head.Value.X + 1, Body.head.Value.Y));
                    break;
            }
        }
        public bool Add(Apple apple)
        {
            if(Body.Contains(apple.Location))
            {
                switch (Dir)
                {
                    case Direction.Up:
                        Body.AddFirst(new(Body.head.Value.X, Body.head.Value.Y - 1));
                        break;
                    case Direction.Down:
                        Body.AddFirst(new(Body.head.Value.X, Body.head.Value.Y + 1));
                        break;
                    case Direction.Left:
                        Body.AddFirst(new(Body.head.Value.X - 1, Body.head.Value.Y));
                        break;
                    case Direction.Right:
                        Body.AddFirst(new(Body.head.Value.X + 1, Body.head.Value.Y));
                        break;
                }
                return true;
            }
            return false;
        }
        public void UpdateDir(KeyboardState keyboardState)
        {
            if (keyboardState.GetPressedKeys().Length > 0)
                ;

            if(keyboardState.IsKeyDown(Keys.Up) && Dir != Direction.Down)
            {
                Dir = Direction.Up;
            }
            else if (keyboardState.IsKeyDown(Keys.Down) && Dir != Direction.Up)
            {
                Dir = Direction.Down;
            }
            else if (keyboardState.IsKeyDown(Keys.Left) && Dir != Direction.Right)
            {
                Dir = Direction.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) && Dir != Direction.Left)
            {
                Dir = Direction.Right;
            }
        }
        public void Draw( SpriteBatch spiteBatch)
        {
            spiteBatch.Draw(head, grid.Squares[Body.head.Value.Y, Body.head.Value.X], Color.White);
            DoublyLinkedNode<Point> current = Body.head.Next;
            for (int i = 1; i < Body.count; i++)
            {
                spiteBatch.Draw(body, grid.Squares[current.Value.Y, current.Value.X], Color.White);
                current = current.Next;
            }
        }
    }
}
