using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNamedWar.Models
{
    public class GameMap
    {
        public Vector2 Position { get; set; } = new Vector2(100, 100);

        public Vector2 Size { get; set; } = new Vector2(10, 10);

        public int a { get; set; } = 50;

        public int LineWidth { get; set; } = 1;

        public void DrawMap(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            int[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            texture.SetData<int>(pixel, 0, texture.Width * texture.Height);

            int hexWidth = (int)(a * Math.Pow(3, 0.5d));
            int hexHeight = a * 3 / 2;

            for (int i = 0; i < Size.Y; i++)
            {
                for (int j = 0; j < Size.X; j++)
                {
                    int x = (int)Position.X + j * hexWidth + ((i % 2 == 0) ? 0 : hexWidth / 2),
                        y = (int)Position.Y + i * hexHeight;

                    spriteBatch.Draw(texture, new Rectangle(x, y, a, LineWidth), null,
                        Color.Red, (float)Math.PI / 2, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    spriteBatch.Draw(texture, new Rectangle(x, y, a, LineWidth), null,
                        Color.Red, -(float)Math.PI / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    spriteBatch.Draw(texture, new Rectangle(x, y + a, a, LineWidth), null,
                        Color.Red, (float)Math.PI / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    spriteBatch.Draw(texture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y, a, LineWidth), null,
                        Color.Red, -(float)Math.PI * 5 / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    spriteBatch.Draw(texture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y, a, LineWidth), null,
                        Color.Red, (float)Math.PI / 2, new Vector2(0f, 0f), SpriteEffects.None, 1f);

                    spriteBatch.Draw(texture, new Rectangle(x + (int)(a * Math.Pow(3, 0.5d)), y + a, a, LineWidth), null,
                        Color.Red, -(float)Math.PI * 7 / 6, new Vector2(0f, 0f), SpriteEffects.None, 1f);
                }
            }
        }
    }
}