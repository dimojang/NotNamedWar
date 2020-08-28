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
        public int x0 { get; set; } = 100;

        public int y0 { get; set; } = 100;

        public int Height { get; set; } = 10;

        public int Width { get; set; } = 10;

        public int a { get; set; } = 50;

        public int LineWidth { get; set; } = 1;


        public void DrawMap(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            int[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            texture.SetData<int>(pixel, 0, texture.Width * texture.Height);

            int hexWidth = (int)(a * Math.Pow(3, 0.5d));
            int hexHeight = a * 3 / 2;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int x = x0 + j * hexWidth + ((i % 2 == 0) ? hexWidth / 2 : 0),
                        y = y0 + i * hexHeight;

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
