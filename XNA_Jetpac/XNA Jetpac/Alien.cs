using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace XNA_Jetpac
{
    public class Alien : Bullet
    {

        new public static Texture2D Texture;
        static Random rand = new Random();
        int MeteorX = rand.Next(0, 800);
        int MeteorY = rand.Next(50, 440);
        int currentAlienFrame = 0;
        int spriteWidth = 35;
        int spriteHeight = 35;

        public Rectangle AlienRect
        {
            get
            {
                return new Rectangle((int)currentAlienFrame * spriteWidth, (int)0, spriteWidth, spriteHeight);
            }
        }

        public Rectangle MeteorRect
        {
            get
            {
                return new Rectangle((int)MeteorX, (int)MeteorY, spriteWidth, spriteHeight);
            }
        }

        public Rectangle ManBoundingRect
        {
            get
            {
                return new Rectangle((int)JetPac.x, (int)JetPac.y, (JetPac.gameSprites.Width / 5 / 2), JetPac.gameSprites.Height);
            }
        }

        Rectangle ledge1Rect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge1X, JetPac.ledge1Y, JetPac.ledge1.Width, JetPac.ledge1.Height);
            }
        }

        Rectangle ledge2Rect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge2X, JetPac.ledge2Y, JetPac.ledge2.Width, JetPac.ledge2.Height);
            }
        }

        Rectangle ledge3Rect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge3X, JetPac.ledge3Y, JetPac.ledge1.Width, JetPac.ledge1.Height);
            }
        }


        public void UpdateMeteor(int level, bool alienReset)
        {
            currentAlienFrame = level;
            JetPac.bullTestMeteorX = MeteorX;
            JetPac.bullTestMeteorY = MeteorY;

            if (MeteorX > -70)
            {
                MeteorX--;
            }
            else
            {
                MeteorX = rand.Next(800, 1200);
                MeteorY = rand.Next(50, 400);
            }
            collide();
            JetPac.MetX = MeteorX;
            JetPac.MetY = MeteorY;
        }

        public void ResetMeteor()
        {
            MeteorX = rand.Next(800, 1200);
            MeteorY = rand.Next(50, 400);
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 MeteorLocation = new Vector2(MeteorX, MeteorY);
            spriteBatch.Draw(Texture, MeteorLocation, AlienRect, Color.White, 0, Vector2.Zero, 1.0f, 0, 0);
        }

        public void collide()
        {
            // Check if meteor hits ledges
            if (MeteorRect.Intersects(ledge1Rect) == true ||
                MeteorRect.Intersects(ledge2Rect) == true ||
                MeteorRect.Intersects(ledge3Rect) == true)
            {
                JetPac.explosionX = MeteorX;
                JetPac.explosionY = MeteorY;
                MeteorX = rand.Next(800, 1200);
                MeteorY = rand.Next(50, 400);
                JetPac.explosionFrame = 0;
                JetPac.explode = true;
            }

            // Check if player hits meteor
            if (ManBoundingRect.Intersects(MeteorRect) == true)
            {
                JetPac.lives--;
                JetPac.x = 200;
                JetPac.y = 360;
                MeteorY = rand.Next(50, 400);
                MeteorX = rand.Next(800, 1200);
                JetPac.died.Play();
                if (JetPac.lives == 0)
                {
                    JetPac.gameOn = false;
                }
            }

            KeyboardState keyboard = Keyboard.GetState();

            foreach (Bullet b in JetPac.fireRight)
            {
                if (b.bulletRightRect.Intersects(MeteorRect) == true)
                {
                    JetPac.deleteFireRight.Add(b);
                    JetPac.explosionX = MeteorX;
                    JetPac.explosionY = MeteorY;
                    MeteorX = rand.Next(800, 1200);
                    MeteorY = rand.Next(50, 400);
                    JetPac.explosionFrame = 0;
                    JetPac.explode = true;
                    JetPac.score += 10;
                    JetPac.collision = true;
                    JetPac.hit.Play();
                }
            }

            foreach (BulletLeft b in JetPac.fireLeft)
            {
                if (b.bulletLeftRect.Intersects(MeteorRect) == true)
                {
                    JetPac.explosionX = MeteorX;
                    JetPac.explosionY = MeteorY;
                    MeteorX = rand.Next(800, 1200);
                    MeteorY = rand.Next(50, 400);
                    JetPac.explosionFrame = 0;
                    JetPac.explode = true;
                    JetPac.score += 10;
                    JetPac.collision = true;
                    JetPac.hit.Play();
                }
            }
        }
    }
}
