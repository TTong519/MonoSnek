using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace MonoSnek
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D Head;
        Texture2D Body;
        Grid grid;
        Snake snake;
        Apple apple;
        int gametime = 0;
        bool abool;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            grid = new(50);
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            abool = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Head = Content.Load<Texture2D>("head");
            Body = Content.Load<Texture2D>("body");
            snake = new Snake(new(4), Head, Body, grid);
            apple = new Apple(new(3, 3), Content.Load<Texture2D>("apple"), grid);
        }
        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            snake.UpdateDir(Keyboard.GetState());
            if (gametime % 300 <= 20 && abool)
            {
                snake.Move();
                abool = false; 
            }
            else if(gametime % 300 > 20)
            {
                abool = true;
            }
            if(snake.Body.count >= 100)
            {
                throw new Exception("you won");
            }
            if(snake.Body.ContainsDuplicates())
            {
                throw new Exception("gaame over");
            }
            snake.Add(apple);
            base.Update(gameTime);
            gametime += ((int)gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            snake.Draw(spriteBatch);
            apple.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
