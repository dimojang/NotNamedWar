using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNamedWar.Models
{
    class GameUI
    {
        /// <summary>
        /// MouseCursor
        /// </summary>
        public Spirit MouseCursor { get; set; } = new Spirit()
        {
            SpiritColor = Color.OrangeRed,
            Width = 5,
            Height = 5,
            Position = new Vector2(0,0)
        };

        public void DrawGameUI(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            #region texture
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            int[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            texture.SetData<int>(pixel, 0, texture.Width * texture.Height);
            #endregion

            /// <summary>
            /// Draw MouseCursor
            /// </summary>
            spriteBatch.Draw(texture,
                new Rectangle(
                    (int)MouseCursor.Position.X, 
                    (int)MouseCursor.Position.Y, 
                    MouseCursor.Width, 
                    MouseCursor.Height), 
                MouseCursor.SpiritColor);
        }
    }
}
