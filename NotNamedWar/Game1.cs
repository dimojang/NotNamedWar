using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace NotNamedWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int x0 = 100, y0 = 100;
        int a = 50;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.A)) x0++;
            if (Keyboard.GetState().IsKeyDown(Keys.D)) x0--;
            if (Keyboard.GetState().IsKeyDown(Keys.W)) y0++;
            if (Keyboard.GetState().IsKeyDown(Keys.S)) y0--;

            a = Mouse.GetState().ScrollWheelValue/100;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            Texture2D SimpleTexture = new Texture2D(GraphicsDevice, 1, 1, false,
                SurfaceFormat.Color);

            int[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            SimpleTexture.SetData<int>(pixel, 0, SimpleTexture.Width * SimpleTexture.Height);
            
            int width = 1;

            int l = 10, h = 10;
            // Paint a 100x1 line starting at 20, 50

            int hexWidth = (int)(a * Math.Pow(3, 0.5d));
            int hexHeight = a * 3 / 2;
            for (int i = 0; i < l; i++)
            {
                for(int j = 0; j < h; j++)
                {
                    int x = x0 + j * hexWidth + ((i % 2 == 0) ? hexWidth / 2 : 0), 
                        y = y0 + i * hexHeight;

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x, y, a, width), null,
                        Color.Red, (float)Math.PI / 2, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x, y, a, width), null,
                        Color.Red, -(float)Math.PI / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x, y + a, a, width), null,
                        Color.Red, (float)Math.PI / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y, a, width), null,
                        Color.Red, -(float)Math.PI * 5 / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y, a, width), null,
                        Color.Red, (float)Math.PI / 2, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    this.spriteBatch.Draw(SimpleTexture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y + a, a, width), null,
                        Color.Red, -(float)Math.PI * 7 / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);
                }
            }






            //this.spriteBatch.Draw(SimpleTexture, new Rectangle(x, y, a, width), Color.Gray);

            //this.spriteBatch.Draw(SimpleTexture, new Rectangle(0, 0, 100, 10), null,
            //    Color.Red, 0, new Vector2(0f, -1), SpriteEffects.None, 1f);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
