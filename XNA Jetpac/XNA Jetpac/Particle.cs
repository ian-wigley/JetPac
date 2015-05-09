using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNA_Jetpac
{
    public class Particle : Microsoft.Xna.Framework.Game
    {
        public static Texture2D Texture;
        static Random rand = new Random();
        static int lifeSpan = 20;
        int particleX;
        int particleY;
        int rocketParticle1X = JetPac.rocket1X;
        int rocketParticle1Y = JetPac.rocket1Y + 40;
        int rocketParticle2X = JetPac.rocket1X + 40;
        int rocketParticle2Y = JetPac.rocket1Y + 40;
        int record;
        int recordRocket = JetPac.rocket3Y + 40 + lifeSpan;
        int count = 0;
        float depth = 1.0f;
        public static Color[] colors = {Color.White,
                          Color.Yellow,
                          Color.Orange,
                          Color.Brown,
                          Color.Red,
                          Color.Brown,
                          Color.Brown,
                          Color.Black             };


        public void updateParticle(int X, int Y, bool facingLeft, bool initialise, bool showParticles)
        {
            if (showParticles == true)
            {
                if (particleY < record)
                {
                    particleY++;

                }
                else if (particleY >= record && JetPac.fullTank == false)
                {
                    if (facingLeft == true)
                    {
                        particleX = X + 20 + rand.Next(0, 10);
                        record = Y + 40 + lifeSpan;
                        particleY = Y + 40 + rand.Next(0, 10);
                    }
                    else
                    {
                        particleX = X + rand.Next(0, 10);
                        record = Y + 40 + lifeSpan;
                        particleY = Y + 40 + rand.Next(0, 10);
                    }
                }

                if (particleY == (record - 20))
                {
                    count = 0;
                    depth = 1.0f;
                }
                if (particleY == (record - 15))
                {
                    count = 1;
                    depth = 0.9f;
                }
                if (particleY == (record - 10))
                {
                    count = 2;
                    depth = 0.8f;
                }
                if (particleY == (record - 5))
                {
                    count = 3;
                    depth = 0.7f;
                }
                if (particleY == (record))
                {
                    count = 4;
                    depth = 0.45f;
                }
            }

            // Hide the particles when not in use
            if (showParticles == false && JetPac.fullTank == false)
            {
                foreach (Particle p in JetPac.part)
                {
                    count = 7;
                    if (particleY < record)
                    {
                        particleY++;
                    }
                }
            }
        }


        public void updateRocketParticle()
        {
            if (rocketParticle1Y < recordRocket)
            {
                rocketParticle1Y++;
                rocketParticle2Y++;
            }
            if (rocketParticle1Y >= recordRocket && JetPac.fullTank == true)
            {
                rocketParticle1X = JetPac.rocket1X + 10 + rand.Next(0, 10);
                recordRocket = JetPac.rocket1Y + 60 + lifeSpan;
                rocketParticle1Y = JetPac.rocket1Y + 60 + rand.Next(0, 10);
                rocketParticle2X = JetPac.rocket1X + 50 + rand.Next(0, 10);
                rocketParticle2Y = JetPac.rocket1Y + 60 + rand.Next(0, 10);
            }
            if (rocketParticle1Y == (recordRocket - 20))
            {
                count = 0;
            }
            if (rocketParticle1Y == (recordRocket - 15))
            {
                count = 1;
            }
            if (rocketParticle1Y == (recordRocket - 10))
            {
                count = 2;
            }
            if (rocketParticle1Y == (recordRocket - 5))
            {
                count = 3;
            }
            if (rocketParticle1Y == (recordRocket))
            {
                count = 4;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (JetPac.fullTank == true)
            {
                spriteBatch.Begin();
                //spriteBatch.Begin(SpriteBlendMode.Additive, SpriteSortMode.Deferred, SaveStateMode.None);
                Vector2 rocketParticle1Location = new Vector2(rocketParticle1X, rocketParticle1Y);
                spriteBatch.Draw(Texture, rocketParticle1Location, colors[count]);
                Vector2 rocketParticle2Location = new Vector2(rocketParticle2X, rocketParticle2Y);
                spriteBatch.Draw(Texture, rocketParticle2Location, colors[count]);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin();
                //spriteBatch.Begin(SpriteBlendMode.Additive, SpriteSortMode.Deferred, SaveStateMode.None);
                Vector2 particleLocation = new Vector2(particleX, particleY);
                //                spriteBatch.Draw(Texture, particleLocation, colors[count]);
                spriteBatch.Draw(Texture, particleLocation, null, colors[count], 0, new Vector2(0, 9), depth, SpriteEffects.None, 0);
                spriteBatch.End();
            }
        }
    }
}
