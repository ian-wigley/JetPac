using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Jetpac
{
    public class BulletLeft
    {
        public static Texture2D Texture;
        int bulletX = JetPac.x;
        int bulletY = JetPac.y + 24;
        int bulletTestX = JetPac.x;
        int bulletTestY = JetPac.y + 24;

        public Rectangle bulletLeftRect
        {
            get
            {
                return new Rectangle((int)bulletTestX, bulletTestY, Bullet.Texture.Width, Bullet.Texture.Height);
            }
        }

        public void UpdateBulletLeft()
        {
            JetPac.bullLeftBoxX = bulletX;
            JetPac.bullLeftBoxY = bulletY;
            if (bulletX >= -50 && JetPac.collision == false)
            {
                bulletX -= 3;
                bulletTestX -= 3;
                JetPac.collisionBulletLeftX = bulletX;
                JetPac.collisionBulletLeftY = bulletY;
            }
            else if (bulletX <= -50 || JetPac.collision == true)
            {
                bulletX = -150;
                foreach (BulletLeft b in JetPac.fireLeft)
                {
                    JetPac.deleteFireLeft.Add(b);
                    JetPac.collisionBulletLeftX = -150;
                    JetPac.collision = false;
                    return;
                }
            }
            return;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 bulletLocation = new Vector2(bulletX, bulletY);
            spriteBatch.Draw(Texture, bulletLocation, Color.White);
        }
    }
}
