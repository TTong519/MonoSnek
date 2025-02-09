using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoSnek
{
    public class Apple
    {
        public Point Location;
        Random random;
        Texture2D texture;
        Grid grid;
        public Apple(Point location, Texture2D texture, Grid grid)
        {
            Location = location;
            random = new Random();
            this.texture = texture;
            this.grid = grid;
        }
        public void Regen()
        {
            Point oldlocation = Location;
            while (oldlocation == Location)
            {
                Location = new(random.Next(10), random.Next(10));
            }
        }
        public void Draw(SpriteBatch spiteBatch)
        {
            spiteBatch.Draw(texture, grid.Squares[Location.Y, Location.X], Color.White);
        }
    }
}
