using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNA_Jetpac
{
    class Fuel : Microsoft.Xna.Framework.Game
    {
        public static Texture2D Texture;
        static Random rand = new Random();
        int fuelCellX = rand.Next(0, 750);
        int fuelCellY = -30;
        public static bool pickedUpCell = false;
        public static bool fuelCellLanded = false;
        Rectangle mLedge1BoundingRect;

        public Rectangle fuelCellRect
        {
            get
            {
                return new Rectangle((int)fuelCellX, (int)fuelCellY, Texture.Width, Texture.Height);
            }
        }

        public Rectangle ManBoundingRect
        {
            get
            {
                return new Rectangle((int)JetPac.x, (int)JetPac.y, (JetPac.gameSprites.Width / 5 / 2), JetPac.gameSprites.Height);
            }
        }

        public Rectangle Ledge1BoundingRect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge1X, (int)JetPac.ledge1Y, JetPac.ledge1.Width, JetPac.ledge1.Height);
            }
            set
            {
                mLedge1BoundingRect = value;
            }
        }
        public Rectangle Ledge2BoundingRect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge2X, (int)JetPac.ledge2Y, JetPac.ledge2.Width, JetPac.ledge2.Height);
            }
        }
        public Rectangle Ledge3BoundingRect
        {
            get
            {
                return new Rectangle((int)JetPac.ledge3X, (int)JetPac.ledge3Y, JetPac.ledge1.Width, JetPac.ledge1.Height);
            }
        }
        public void updateFuelCell()
        {
            if (fuelCellY < 472 && fuelCellLanded == false && pickedUpCell == false)
            {
                fuelCellY++;
                if (fuelCellY >= 472)
                {
                    fuelCellLanded = true;
                }
            }
            //Intersect with ledges
            if (fuelCellRect.Intersects(Ledge1BoundingRect) ||
                fuelCellRect.Intersects(Ledge2BoundingRect) ||
                fuelCellRect.Intersects(Ledge3BoundingRect))
            {
                fuelCellY -= 1;
                fuelCellLanded = true;
            }

            if (ManBoundingRect.Intersects(fuelCellRect) && fuelCellLanded == true)
            {
                pickedUpCell = true;
            }

            if (pickedUpCell == true && fuelCellX != 430)
            {
                fuelCellX = JetPac.x;
                fuelCellY = JetPac.y + 20;
            }
            if (fuelCellX == 430 && fuelCellY < 472)
            {
                fuelCellY++;
                if (fuelCellY >= 472)
                {
                    JetPac.fuelLevel += 25;
                    fuelCellX = rand.Next(30, 770);
                    fuelCellY = -30;
                    if (JetPac.fuelLevel < 100)
                    {
                        fuelCellLanded = false;
                    }
                    else JetPac.fullTank = true;
                    pickedUpCell = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 fuelCellLocation = new Vector2(fuelCellX, fuelCellY);
            spriteBatch.Draw(Texture, fuelCellLocation, Color.White);
        }
    }
}

