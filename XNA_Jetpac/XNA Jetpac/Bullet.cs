using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Jetpac
{
    public class Bullet : BulletLeft
    {
        new public static Texture2D Texture;
        int bulletRightX = JetPac.x;
        int bulletRightY = JetPac.y + 24;
        int bulletTestX = JetPac.x;
        int bulletTestY = JetPac.y + 24;

        public Rectangle bulletRightRect
        {
            get
            {
                return new Rectangle((int)bulletTestX, bulletTestY, Bullet.Texture.Width, Bullet.Texture.Height);
            }
        }

        public void UpdateBullet()
        {
            JetPac.bullRightBoxX = bulletRightX;
            JetPac.bullRightBoxY = bulletRightY;

            if (bulletRightX < 800 && JetPac.collision == false)
            {
                this.bulletRightX += 3;
                JetPac.bullRightBoxX += 3;
                bulletTestX += 3;

                JetPac.collisionBulletRightX = bulletRightX;
                JetPac.collisionBulletRightY = bulletRightY;
            }
            else if (this.bulletRightX >= 800 || JetPac.collision == true)
            {
                bulletRightX = -150;
                foreach (Bullet b in JetPac.fireRight)
                {
                    JetPac.deleteFireRight.Add(b);
                    JetPac.collisionBulletRightX = -150;
                    JetPac.collision = false;
                    return;
                }
            }
        }

        public void DrawBullet(SpriteBatch spriteBatch)
        {
            Vector2 bulletLocation = new Vector2(bulletRightX, bulletRightY);
            spriteBatch.Draw(Texture, bulletLocation, Color.White);
        }
    }
}
