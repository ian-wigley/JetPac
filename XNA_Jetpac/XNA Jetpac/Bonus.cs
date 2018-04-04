using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNA_Jetpac
{
    class Bonus : Fuel
    {
        new public static Texture2D Texture;
        static Random rand = new Random();
        int mBonusX = rand.Next(0, 750);
        int mBonusY = -30;
        int currentBonusFrame = rand.Next(0, 4);
        int bonusWidth = 32;
        int bonusHeight = 27;
        bool pickedUpBonus = false;
        public static bool bonusLanded = false;


        public Rectangle bonusRect
        {
            get
            {
                return new Rectangle((int)currentBonusFrame * bonusWidth, (int)0, bonusWidth, bonusHeight);
            }
        }

        public Rectangle bonusCollisionRect
        {
            get
            {
                return new Rectangle((int)mBonusX, (int)mBonusY, bonusWidth, bonusHeight);
            }
        }

        public void updateBonus()
        {
            if (mBonusY < 472 && bonusLanded == false && pickedUpBonus == false)
            {
                mBonusY++;
                if (mBonusY >= 472)
                {
                    bonusLanded = true;
                }
            }

            //Intersect with ledges
            if (bonusCollisionRect.Intersects(base.Ledge1BoundingRect) ||
                bonusCollisionRect.Intersects(base.Ledge2BoundingRect) ||
                bonusCollisionRect.Intersects(base.Ledge3BoundingRect))
            {
                mBonusY -= 1;
                bonusLanded = true;
            }

            if (bonusLanded == true)
            {
                if (base.ManBoundingRect.Intersects(bonusCollisionRect))
                {
                    mBonusX = rand.Next(0, 750);
                    mBonusY = -30;
                    bonusLanded = false;
                    currentBonusFrame = rand.Next(0, 4);
                    JetPac.score += 50;
                }
            }
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 bonusLocation = new Vector2(mBonusX, mBonusY);
            spriteBatch.Draw(Texture, bonusLocation, bonusRect, Color.White, 0, Vector2.Zero, 1.0f, 0, 0);
        }
    }
}
