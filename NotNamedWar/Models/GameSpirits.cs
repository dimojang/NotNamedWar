using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotNamedWar.Models;

namespace NotNamedWar.Models
{
    class GameSpirits
    {
        public List<Spirit> Spirits { get; set; } = new List<Spirit>();

        private float[] rotations = new float[6] { 0, -(float)Math.PI / 3, -(float)Math.PI * 2 / 3, -(float)Math.PI, (float)Math.PI * 2 / 3, (float)Math.PI / 3 };

        public void DrawSpirits(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, GameMap gameMap)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            int[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            texture.SetData<int>(pixel, 0, texture.Width * texture.Height);

            int hexWidth = (int)(gameMap.a * Math.Pow(3, 0.5d));
            int hexHeight = gameMap.a * 2;

            int Length = (int)(gameMap.a * Math.Pow(3, 0.5d) / 2);

            foreach (Spirit spirit in Spirits)
            {
                int x = (int)gameMap.Position.X + ((int)spirit.Position.X - 1) * hexWidth + ((spirit.Position.Y % 2 == 0) ? hexWidth / 2 : 0) + hexWidth / 2;
                int y = (int)gameMap.Position.Y + ((int)spirit.Position.Y - 1) * hexHeight * 3 / 4 + hexHeight / 4;

                int l = spirit.Width == 1 ? 50 : ((spirit.Width - 2) * 2 + 2) * Length;
                
                spriteBatch.Draw(texture, new Rectangle(x, y, l, spirit.Width), null,
                    spirit.SpiritColor, rotations[spirit.Direction], new Vector2(0f, 0f), SpriteEffects.None, 1f);

                spriteBatch.Draw(texture, new Rectangle(x, y, 10, 10), Color.Red);
            }
        }
    }
}
