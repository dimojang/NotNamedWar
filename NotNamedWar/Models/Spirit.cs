using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNamedWar.Models
{
    class Spirit
    {
        public Color SpiritColor { get; set; } = Color.Red;

        public int Direction { get; set; } = 1;

        public int Length { get; set; } = 2;

        public int Width { get; set; } = 1;

        public Vector2 Position { get; set; } = new Vector2(5, 5);
    }
}
