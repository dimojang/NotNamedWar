using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotNamedWar.Models;
using System;

namespace NotNamedWar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameMap gameMap = new GameMap();
        GameSpirits gameSpirits = new GameSpirits();
        GameUI gameUI = new GameUI();

        public MainGame()
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
            gameSpirits.Spirits.Add(
                new Spirit()
                {
                    Direction = 1,
                    Width = 3,
                    Position = new Vector2(5, 5),
                    SpiritColor = Color.White,
                    Height = 1
                });

            gameSpirits.Spirits.Add(
                new Spirit()
                {
                    Direction = 3,
                    Width = 2,
                    Position = new Vector2(7, 7),
                    SpiritColor = Color.White,
                    Height = 5
                });

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
            if (Keyboard.GetState().IsKeyDown(Keys.A)) gameMap.Position += new Vector2(10,0);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) gameMap.Position -= new Vector2(10, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.W)) gameMap.Position += new Vector2(0, 10);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) gameMap.Position -= new Vector2(0, 10);

            gameMap.a = Mouse.GetState().ScrollWheelValue/100;

            gameUI.MouseCursor.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

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


            gameMap.DrawMap(spriteBatch, GraphicsDevice);
            gameSpirits.DrawSpirits(spriteBatch, GraphicsDevice, gameMap);
            gameUI.DrawGameUI(spriteBatch, GraphicsDevice);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
