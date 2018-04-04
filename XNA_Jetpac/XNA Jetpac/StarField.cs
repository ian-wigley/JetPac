using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNA_Jetpac
{
    class StarField : Microsoft.Xna.Framework.Game
    {
        public static Texture2D Texture;
        static Random rand = new Random();
        int starLayer1X = rand.Next(0, 800);
        int starLayer1Y = rand.Next(50, 440);

        int starLayer2X = rand.Next(0, 800);
        int starLayer2Y = rand.Next(52, 440);

        public void updateStarField()
        {
            if (starLayer1X < 800)
            {
                starLayer1X++;
            }
            else
            {
                starLayer1X = rand.Next(-400, 0);
            }

            if (starLayer2X < 800)
            {
                starLayer2X += 2;
            }
            else
            {
                starLayer2X = rand.Next(-400, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 starLocationLayer1 = new Vector2(starLayer1X, starLayer1Y);
            spriteBatch.Draw(Texture, starLocationLayer1, Color.DarkGray);

            Vector2 starLocationLayer2 = new Vector2(starLayer2X, starLayer2Y);
            spriteBatch.Draw(Texture, starLocationLayer2, Color.White);
        }
    }
}
