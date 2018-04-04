//////////////////////////////////////////////////////////
//                                                      //
// XNA JetPac - Written by Ian Wigley                   //
// Started in Oct'08                                    //
// Finished in May 2009                                 //
//                                                      //
//////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace XNA_Jetpac
{
    /// <summary>
    /// JetPac Remake using the awesome XNA Start date Oct 08 - finish date ??
    /// </summary>

    public class JetPac : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int count = 0;

        bool tripSwitch = false;
        public static bool bulletFlag = false;

        public static Color[] colors = {Color.White,
                          Color.Yellow,
                          Color.Orange,
                          Color.Red,
                          Color.Brown,
                          Color.Red,
                          Color.Orange,
                          Color.Yellow,
                          Color.White };


        public static List<Alien> enemies = new List<Alien>();

        List<StarField> stars = new List<StarField>();

        public static List<Particle> part = new List<Particle>();

        List<Fuel> fuelcell = new List<Fuel>();
        List<Bonus> extras = new List<Bonus>();

        public static bool alienReset = false;

        static bool getNextPiece = false;

        public static Rectangle mainSpritesRect;

        public static List<BulletLeft> fireLeft = new List<BulletLeft>();
        public static List<BulletLeft> deleteFireLeft = new List<BulletLeft>();

        public static List<Bullet> fireRight = new List<Bullet>();
        public static List<Bullet> deleteFireRight = new List<Bullet>();

        public static int bullRightBoxX = 0;
        public static int bullRightBoxY = 0;
        public static int bullLeftBoxX = 0;
        public static int bullLeftBoxY = 0;
        public static int bullTestMeteorX = 0;
        public static int bullTestMeteorY = 0;

        public static int MetY;
        public static int MetX;

        static Random rand = new Random();

        public static int score = 0;
        public static int lives = 3;
        static int currentFrame = 0;
        int spriteWidth = 36;
        int spriteHeight = 51;

        public static int fuelLevel = 0;

        public static int explosionX = -100;
        public static int explosionY = 0;
        public static int explosionFrame = 0;
        public static int x = 150;
        public static int y = 300;

        public static bool facingLeft = false;
        public static bool bulletFired = false;
        public static bool gameOn = false;

        public static bool initialise = true;

        static int rocketWidth = 75;
        static int rocketHeight = 61;
        public static int rocket1X = 422;
        public static int rocket1Y = 440;
        static int rocketFrame1 = 0;

        static int rocket2X = 110;
        static int rocket2Y = 140;
        static int rocketFrame2 = 4;

        public static int rocket3X = 510;
        public static int rocket3Y = 177;
        static int rocketFrame3 = 8;

        int floorX = 0;
        int floorY = 500;

        static int level = 16;
        static int alien = 0;

        public static int ledge1X = 60;
        public static int ledge1Y = 200;

        public static int ledge3X = 490;
        public static int ledge3Y = 136;

        public static int ledge2X = 310;
        public static int ledge2Y = 265;

        int explosionWidth = 64;
        int explosionHeight = 64;

        bool onFloor = false;
        static bool onGround = false;
        static bool showParticles = false;
        static bool pickedUpFirstPiece = false;
        static bool deliveredFirstPiece = false;
        static bool pickedUpSecondPiece = false;
        static bool deliveredSecondPiece = false;
        static bool lowerFirstPiece = false;
        public static bool clearForTakeOff = false;
        public static bool fullTank = false;

        public static bool explode = false;

        public static bool collision = false;
        public static int collisionBulletRightX = -150;
        public static int collisionBulletRightY = -100;
        public static int collisionBulletLeftX = -1;
        public static int collisionBulletLeftY = -100;
        public static int collisionMeteorX = 0;
        public static int collisionMeteorY = 0;

        public static int MeteorHeight = 0;
        public static int MeteorWidth = 0;

        static Rectangle gameSpritesRect;
        Rectangle destinationRect;
        Rectangle rocketRect1;
        Rectangle rocketRect2;
        Rectangle rocketRect3;
        public static Rectangle explosionRect;

        private SpriteEffects flip = SpriteEffects.None;

        private Texture2D menuBackground;
        public static Texture2D gameSprites;
        private Texture2D rocketSprites;
        private Texture2D floor;
        public static Texture2D ledge1;
        public static Texture2D ledge2;
        public static Texture2D explosion;
        public static Texture2D particle;

        private SpriteFont hudFont;

        protected double bulletTimer = 0;
        protected double animTimer = 0;
        protected const double elapsedSecs = 0.1f;
        protected double explosionAnimTimer = 0;
        protected const double explosionElapsedSecs = 0.1f;

        protected Rectangle screenBounds;

        public static SoundEffect died;
        public static SoundEffect fire;
        public static SoundEffect hit;

        public JetPac()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menuBackground = Content.Load<Texture2D>("loading");
            gameSprites = Content.Load<Texture2D>("sprites");
            rocketSprites = Content.Load<Texture2D>("rocket_sprites");
            floor = Content.Load<Texture2D>("floor");
            ledge1 = Content.Load<Texture2D>("ledge1");
            ledge2 = Content.Load<Texture2D>("ledge2");
            explosion = Content.Load<Texture2D>("explosion");

            Alien.Texture = Content.Load<Texture2D>("meteor");
            BulletLeft.Texture = Content.Load<Texture2D>("bullet");
            Bullet.Texture = Content.Load<Texture2D>("bullet");
            Particle.Texture = Content.Load<Texture2D>("particle");
            StarField.Texture = Content.Load<Texture2D>("star");
            Fuel.Texture = Content.Load<Texture2D>("fuel_cell");
            Bonus.Texture = Content.Load<Texture2D>("bonus");

            // Load fonts
            hudFont = Content.Load<SpriteFont>("Hud");

            died = Content.Load<SoundEffect>("died");
            fire = Content.Load<SoundEffect>("fire");
            hit = Content.Load<SoundEffect>("hit");


            destinationRect = new Rectangle(0, 0, spriteWidth, spriteHeight);

            // TODO: use this.Content to load your game content here
            //create a new Objects and add to respective list's
            for (int i = 0; i < 10; i++)
            {
                Alien m = new Alien();
                enemies.Add(m);
            }
            for (int j = 0; j < 40; j++)
            {
                StarField s = new StarField();
                stars.Add(s);
            }
            for (int k = 0; k < 40; k++)
            {
                Particle p = new Particle();
                part.Add(p);
            }
            Fuel f = new Fuel();
            fuelcell.Add(f);

            Bonus b = new Bonus();
            extras.Add(b);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            // Get current gamepad and keyboard states
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            if (gameOn == false)
            {
                // Back or Escape exits our game on Xbox 360 and Windows
                if (gamePad.Buttons.Back == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Escape))
                    this.Exit();

                if (gamePad.Buttons.Back == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.X))
                {
                    gameOn = true;
                    lives = 3;
                    score = 0;
                    getNextPiece = false;
                    pickedUpFirstPiece = false;
                    pickedUpSecondPiece = false;
                    clearForTakeOff = false;
                    lowerFirstPiece = false;
                    deliveredFirstPiece = false;
                    deliveredSecondPiece = false;
                    level = 0;
                    rocketFrame1 = 0;
                    rocketFrame2 = 4;
                    rocketFrame3 = 8;
                    rocket1X = 422;
                    rocket1Y = 443;
                    rocket2X = 110;
                    rocket2Y = 139;
                    rocket3X = 510;
                    rocket3Y = 75;
                }
                base.Update(gameTime);
            }
            else
            {
                // Back or Escape exits our game on Xbox 360 and Windows
                if (gamePad.Buttons.Back == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Escape))
                    this.Exit();

                if (gamePad.DPad.Up == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Up))
                {
                    y -= 2;
                    onGround = false;
                    showParticles = true;
                    tripSwitch = false;
                }

                if (gamePad.DPad.Down == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Down))
                {
                    if (onGround == false)
                    {
                        y += 2;
                    }
                }

                if (gamePad.DPad.Left == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Left))
                {
                    facingLeft = true;
                    x -= 2;

                    if (onGround == true || onFloor == true)
                    {
                        animTimer += elapsedSecs;
                        if (animTimer > 0.4)
                        {
                            animTimer = 0;
                            currentFrame++;
                        }
                    }
                    if (currentFrame >= 4)
                    {
                        currentFrame = 1;
                    }
                }
                if (gamePad.DPad.Right == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.Right))
                {
                    x += 2;
                    facingLeft = false;

                    if (onGround == true || onFloor == true)
                    {
                        animTimer += elapsedSecs;
                        if (animTimer > 0.4)
                        {
                            animTimer = 0;
                            currentFrame++;
                        }
                    }
                    if (currentFrame >= 4)
                    {
                        currentFrame = 1;
                    }
                }

                //Left Ctrl key pressed ? Fire then !!
                if (gamePad.Buttons.A == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.LeftControl))
                {
                    if (facingLeft == true && bulletFlag == false)
                    {
                        BulletLeft b = new BulletLeft();
                        fireLeft.Add(b);
                        //                      fire.Play();
                        bulletFlag = true;
                    }
                    else
                    {
                        if (bulletFlag == false)
                        {
                            Bullet b = new Bullet();
                            fireRight.Add(b);
                            //                          fire.Play();
                            bulletFlag = true;
                        }
                    }
                }

                if (gamePad.Buttons.A == ButtonState.Pressed ||
                    keyboard.IsKeyDown(Keys.LeftControl) == false)
                {
                    bulletFlag = false;
                }

                if (gamePad.DPad.Up == ButtonState.Released &&
                keyboard.IsKeyDown(Keys.Up) == false)
                {
                    showParticles = false;
                }

                if (gamePad.DPad.Down == ButtonState.Released ||
                keyboard.IsKeyDown(Keys.Down))
                {
                    y += 1;
                }

                if (y <= 50)
                {
                    y = 50;
                }

                if (x <= 0)
                {
                    x = 0;
                }
                if (x >= 750)
                {
                    x = 750;
                }

                Rocket();

                foreach (Particle p in part)
                {
                    p.updateParticle(x, y, facingLeft, initialise, showParticles);
                }

                foreach (StarField s in stars)
                {
                    s.updateStarField();
                }
                if (clearForTakeOff == true)
                {
                    foreach (Fuel f in fuelcell)
                    {
                        f.updateFuelCell();
                    }
                    foreach (Bonus b in extras)
                    {
                        b.updateBonus();
                    }
                }


                foreach (Alien m in enemies)
                {
                    m.UpdateMeteor(alien, alienReset);
                }

                foreach (BulletLeft b in fireLeft)
                {
                    b.UpdateBulletLeft();
                }

                foreach (Bullet b in fireRight)
                {
                    b.UpdateBullet();
                }

                foreach (Bullet b in deleteFireRight)
                {
                    fireRight.Remove(b);
                }

                foreach (BulletLeft b in deleteFireLeft)
                {
                    fireLeft.Remove(b);
                }


                Rectangle floorRect = new Rectangle((int)floorX, (int)floorY, floor.Width, floor.Height);
                Rectangle ledge1Rect = new Rectangle((int)ledge1X, (int)ledge1Y, ledge1.Width, ledge1.Height);
                Rectangle ledge2Rect = new Rectangle((int)ledge2X, (int)ledge2Y, ledge2.Width, ledge2.Height);
                Rectangle ledge3Rect = new Rectangle((int)ledge3X, (int)ledge3Y, ledge1.Width, ledge1.Height);

                gameSpritesRect = new Rectangle((int)currentFrame * spriteWidth, (int)0, spriteWidth, spriteHeight);
                Rectangle mainSpritesRect = new Rectangle((int)x, (int)y, spriteWidth, spriteHeight);

                rocketRect1 = new Rectangle(rocketFrame1 * rocketWidth, 0, rocketWidth, rocketHeight);

                rocketRect2 = new Rectangle(rocketFrame2 * rocketWidth, 0, rocketWidth, rocketHeight);
                Rectangle collectRocketRect2 = new Rectangle((int)rocket2X, (int)rocket2Y, rocketWidth, rocketHeight);

                rocketRect3 = new Rectangle(rocketFrame3 * rocketWidth, 0, rocketWidth, rocketHeight);
                Rectangle collectRocketRect3 = new Rectangle((int)rocket3X, (int)rocket3Y, rocketWidth, rocketHeight);

                explosionRect = new Rectangle(explosionFrame * explosionWidth, 0, explosionWidth, explosionHeight);

                if (mainSpritesRect.Intersects(floorRect))
                {
                    if (mainSpritesRect.Bottom - 3 == floorRect.Top ||
                        mainSpritesRect.Bottom - 2 == floorRect.Top ||
                        mainSpritesRect.Bottom - 1 == floorRect.Top ||
                        mainSpritesRect.Bottom == floorRect.Top)
                    {
                        onGround = true;
                        y -= 1;
                        if (tripSwitch == false)
                        {
                            currentFrame += 1;
                            tripSwitch = true;
                        }
                    }
                }

                //Intersect with top left ledge
                if (mainSpritesRect.Intersects(ledge1Rect))
                {
                    if (mainSpritesRect.Bottom - 3 == ledge1Rect.Top ||
                        mainSpritesRect.Bottom - 2 == ledge1Rect.Top ||
                        mainSpritesRect.Bottom - 1 == ledge1Rect.Top ||
                        mainSpritesRect.Bottom == ledge1Rect.Top)
                    {
                        onGround = true;
                        y -= 1;
                        if (tripSwitch == false)
                        {
                            currentFrame += 1;
                            tripSwitch = true;
                        }
                    }
                    if (mainSpritesRect.Top + 1 == ledge1Rect.Bottom)
                    {
                        y += 2;
                    }
                    if (mainSpritesRect.Right - 2 == ledge1Rect.Left)
                    {
                        x -= 2;
                    }
                    if (mainSpritesRect.Left + 1 == ledge1Rect.Right)
                    {
                        x += 2;
                    }
                }

                //Intersect with middle lower ledge
                if (mainSpritesRect.Intersects(ledge2Rect))
                {
                    if (mainSpritesRect.Bottom - 3 == ledge2Rect.Top ||
                        mainSpritesRect.Bottom - 2 == ledge2Rect.Top ||
                        mainSpritesRect.Bottom - 1 == ledge2Rect.Top ||
                        mainSpritesRect.Bottom == ledge2Rect.Top)
                    {
                        onGround = true;
                        y -= 1;
                        if (tripSwitch == false)
                        {
                            currentFrame += 1;
                            tripSwitch = true;
                        }
                    }
                    if (mainSpritesRect.Top + 1 == ledge2Rect.Bottom)
                    {
                        y += 2;
                    }
                    if (mainSpritesRect.Right - 2 == ledge2Rect.Left)
                    {
                        x -= 2;
                    }
                    if (mainSpritesRect.Left + 1 == ledge2Rect.Right)
                    {
                        x += 2;
                    }
                }

                //Intersect with top right ledge
                if (mainSpritesRect.Intersects(ledge3Rect))
                {
                    if (mainSpritesRect.Bottom - 3 == ledge3Rect.Top ||
                        mainSpritesRect.Bottom - 2 == ledge3Rect.Top ||
                        mainSpritesRect.Bottom - 1 == ledge3Rect.Top ||
                        mainSpritesRect.Bottom == ledge3Rect.Top)
                    {
                        onGround = true;
                        y -= 1;
                        if (tripSwitch == false)
                        {
                            currentFrame += 1;
                            tripSwitch = true;
                        }
                    }
                    if (mainSpritesRect.Top + 1 == ledge3Rect.Bottom)
                    {
                        y += 2;
                    }
                    if (mainSpritesRect.Right - 2 == ledge3Rect.Left)
                    {
                        x -= 2;
                    }
                    if (mainSpritesRect.Left + 1 == ledge3Rect.Right)
                    {
                        x += 2;
                    }
                }

                if (mainSpritesRect.Bottom - 3 != floorRect.Top &&
                    mainSpritesRect.Bottom - 2 != floorRect.Top &&
                    mainSpritesRect.Bottom - 1 != floorRect.Top &&
                    mainSpritesRect.Bottom != floorRect.Top &&

                    mainSpritesRect.Bottom - 3 != ledge1Rect.Top &&
                    mainSpritesRect.Bottom - 2 != ledge1Rect.Top &&
                    mainSpritesRect.Bottom - 1 != ledge1Rect.Top &&
                    mainSpritesRect.Bottom != ledge1Rect.Top &&

                    mainSpritesRect.Bottom - 3 != ledge2Rect.Top &&
                    mainSpritesRect.Bottom - 2 != ledge2Rect.Top &&
                    mainSpritesRect.Bottom - 1 != ledge2Rect.Top &&
                    mainSpritesRect.Bottom != ledge2Rect.Top &&

                    mainSpritesRect.Bottom - 3 != ledge3Rect.Top &&
                    mainSpritesRect.Bottom - 2 != ledge3Rect.Top &&
                    mainSpritesRect.Bottom - 1 != ledge3Rect.Top &&
                    mainSpritesRect.Bottom != ledge3Rect.Top)
                {
                    onGround = false;
                    currentFrame = 0;
                }

                //Intersect with rocket piece to collect one
                if (mainSpritesRect.Intersects(collectRocketRect2) && deliveredFirstPiece == false)
                {
                    pickedUpFirstPiece = true;
                }
                //Intersect with rocket piece to collect one
                if (mainSpritesRect.Intersects(collectRocketRect3) && getNextPiece == true)
                {
                    pickedUpSecondPiece = true;
                }

                if (explode == true)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        explosionAnimTimer += explosionElapsedSecs;
                        if (explosionAnimTimer > 4.2)
                        {
                            explosionFrame++;
                            explosionAnimTimer = 0;
                            if (explosionFrame == 16)
                            {
                                explode = false;
                            }
                        }
                    }
                }
                if (lives == 0)
                {
                    gameOn = false;
                }
                base.Update(gameTime);
            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            graphics.GraphicsDevice.Clear(Color.Black);

            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            spriteBatch.Begin();


            if (gameOn == false)
            {
                animTimer += elapsedSecs;
                if (animTimer > 0.4)
                {
                    animTimer = 0;
                    count++;
                }
                Vector2 menuBackgroundLocation = new Vector2(0, 0);
                spriteBatch.Draw(menuBackground, menuBackgroundLocation, Color.White);

                Vector2 textLocation = new Vector2(10, 10);
                spriteBatch.DrawString(hudFont, "JetPac the XNA Remake ", textLocation + new Vector2(150.0f, 420.0f), Color.Yellow);
                spriteBatch.DrawString(hudFont, "Written by Ian Wigley ", textLocation + new Vector2(150.0f, 440.0f), Color.Yellow);
                spriteBatch.DrawString(hudFont, "in 2009   Version 1.1 ", textLocation + new Vector2(150.0f, 460.0f), Color.Yellow);
                spriteBatch.DrawString(hudFont, "Press X to start ", textLocation + new Vector2(150.0f, 520.0f), colors[count]);
                if (count == 8)
                {
                    count = 0;
                }
                spriteBatch.End();
                base.Draw(gameTime);
            }
            else
            {
                if (facingLeft == true)
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    flip = SpriteEffects.None;
                }

                //            spriteBatch.Draw(backgroundTexture, new Rectangle(10, 10,graphics.GraphicsDevice.DisplayMode.Width/2,
                //            graphics.GraphicsDevice.DisplayMode.Height/2),Color.LightGray);


                foreach (StarField s in stars)
                {
                    s.Draw(spriteBatch);
                }

                if (clearForTakeOff == true)
                {
                    foreach (Fuel f in fuelcell)
                    {
                        f.Draw(spriteBatch);
                    }
                    foreach (Bonus b in extras)
                    {
                        b.Draw(spriteBatch);
                    }
                }

                foreach (Alien m in enemies)
                {
                    m.Draw(spriteBatch);
                }

                foreach (BulletLeft b in fireLeft)
                {
                    b.Draw(spriteBatch);
                }

                foreach (Bullet b in fireRight)
                {
                    b.DrawBullet(spriteBatch);
                }

                Vector2 rocket1Location = new Vector2(rocket1X, rocket1Y);
                spriteBatch.Draw(rocketSprites, rocket1Location, rocketRect1, Color.White);

                Vector2 ledge1Location = new Vector2(ledge1X, ledge1Y);
                spriteBatch.Draw(ledge1, ledge1Location, Color.White);

                Vector2 rocket2Location = new Vector2(rocket2X, rocket2Y);
                spriteBatch.Draw(rocketSprites, rocket2Location, rocketRect2, Color.White);

                Vector2 ledge2Location = new Vector2(ledge2X, ledge2Y);
                spriteBatch.Draw(ledge2, ledge2Location, Color.White);

                Vector2 rocket3Location = new Vector2(rocket3X, rocket3Y);
                spriteBatch.Draw(rocketSprites, rocket3Location, rocketRect3, Color.White);

                Vector2 ledge3Location = new Vector2(ledge3X, ledge3Y);
                spriteBatch.Draw(ledge1, ledge3Location, Color.White);

                Vector2 explosionLocation = new Vector2(explosionX, explosionY);
                spriteBatch.Draw(explosion, explosionLocation, explosionRect, Color.White);


                Vector2 floorLocation = new Vector2(floorX, floorY);
                //                spriteBatch.Draw(floor, floorLocation, floorRect, Color.White);
                spriteBatch.Draw(floor, floorLocation, Color.White);

                Vector2 screenLocation = new Vector2(x, y);
                spriteBatch.Draw(gameSprites, screenLocation, gameSpritesRect, Color.White, 0, Vector2.Zero, 1.0f, flip, 0);

                Vector2 scoreLocation = new Vector2(10, 10);
                if (score == 0)
                {
                    spriteBatch.DrawString(hudFont, "SCORE : 000" + score, scoreLocation + new Vector2(1.0f, 1.0f), Color.Yellow);
                }
                else if (score >= 10 && score < 100)
                {
                    spriteBatch.DrawString(hudFont, "SCORE : 00" + score, scoreLocation + new Vector2(1.0f, 1.0f), Color.Yellow);
                }
                else
                {
                    spriteBatch.DrawString(hudFont, "SCORE : 0" + score, scoreLocation + new Vector2(1.0f, 1.0f), Color.Yellow);
                }
                Vector2 liveLocation = new Vector2(10, 10);
                spriteBatch.DrawString(hudFont, "FUEL : " + fuelLevel + "%", scoreLocation + new Vector2(350.0f, 1.0f), Color.Yellow);
                spriteBatch.DrawString(hudFont, "LIVES : " + lives, scoreLocation + new Vector2(700.0f, 1.0f), Color.Yellow);

                // spriteBatch.DrawString(hudFont, "onGround " + onGround, scoreLocation + new Vector2(1.0f, 60.0f), Color.Yellow);
                // spriteBatch.DrawString(hudFont, "tripSwitch " + tripSwitch, scoreLocation + new Vector2(1.0f, 75.0f), Color.Yellow);
                //            spriteBatch.DrawString(hudFont, "bullTestX " + bullTestX, scoreLocation + new Vector2(1.0f, 90.0f), Color.Yellow);
                //            spriteBatch.DrawString(hudFont, "bullTestY " + bullTestY, scoreLocation + new Vector2(1.0f, 115.0f), Color.Yellow);
                //            spriteBatch.DrawString(hudFont, "bullTestMeteorX " + bullTestMeteorX, scoreLocation + new Vector2(1.0f, 130.0f), Color.Yellow);
                //            spriteBatch.DrawString(hudFont, "bullTestMeteorY " + bullTestMeteorY, scoreLocation + new Vector2(1.0f, 145.0f), Color.Yellow);
                spriteBatch.End();
                foreach (Particle p in part)
                {
                    p.Draw(spriteBatch);
                }
                //                spriteBatch.End();

                base.Draw(gameTime);
            }
        }

        static void Rocket()
        {
            if (pickedUpFirstPiece == true)
            {
                if (x != 422)
                {
                    rocket2X = x;
                    rocket2Y = y;
                }
                else if (x == 422 && rocket2Y <= 392)
                {
                    rocket2X = 422;
                    pickedUpFirstPiece = false;
                    lowerFirstPiece = true;
                    deliveredFirstPiece = true;
                }
            }

            if (lowerFirstPiece == true && rocket2Y <= 384 && clearForTakeOff == false) //392
            {
                rocket2Y++;
                if (rocket2Y == 384)
                {
                    score += 100;
                    getNextPiece = true;
                }
            }

            if (pickedUpSecondPiece == true)
            {
                if (x != 422)
                {
                    rocket3X = x;
                    rocket3Y = y;
                }
                else if (x == 422 && rocket3Y <= 332)
                {
                    rocket3X = 422;
                    pickedUpSecondPiece = false;
                    deliveredSecondPiece = true;
                    getNextPiece = false;
                }
            }
            if (deliveredSecondPiece == true && rocket3Y <= 326 && clearForTakeOff == false)
            {
                rocket3Y++;
                if (rocket3Y == 326)//332
                {
                    score += 100;
                    clearForTakeOff = true;
                }
            }
            if (clearForTakeOff == true && fullTank == true && rocket1Y > -100)
            {
                x = -150;
                y = -150;
                rocket3Y -= 2;//-;
                rocket2Y -= 2;//-;
                rocket1Y -= 2;//-;
                foreach (Particle p in part)
                {
                    p.updateRocketParticle();
                }
            }
            // Is our rocket off screen ?
            if (rocket1Y <= -100)
            {
                level++;
                alienReset = true;
                alien++;
                if (alien == 8)
                {
                    alien = 0;
                }

                foreach (Alien m in enemies)
                {
                    m.ResetMeteor();
                }

                fullTank = false;
                fuelLevel = 0;
                if (level == 4 || level == 8 || level == 12)
                {
                    clearForTakeOff = false;
                    lowerFirstPiece = false;
                    deliveredFirstPiece = false;
                    deliveredSecondPiece = false;
                    Fuel.fuelCellLanded = false;
                }
            }
            if (clearForTakeOff == true && fullTank == false && rocket1Y < 440)
            {
                showParticles = true;
                rocket3Y += 2;//+;
                rocket2Y += 2;//+;
                rocket1Y += 2;//+;
                if (clearForTakeOff == true && fullTank == false && rocket1Y >= 440)
                {
                    Fuel.fuelCellLanded = false;
                }
            }

            if (rocket1Y <= -100 && level == 4 ||
                rocket1Y <= -100 && level == 8 ||
                rocket1Y <= -100 && level == 12 ||
                rocket1Y <= -100 && level == 16)
            {
                x = 150;
                y = 300;
                clearForTakeOff = false;
                lowerFirstPiece = false;
                deliveredFirstPiece = false;
                deliveredSecondPiece = false;

                rocket1X = 422;
                rocket1Y = 445;
                rocketFrame1++;
                rocket2X = 110;
                rocket2Y = 145;
                rocketFrame2++;
                rocket3X = 510;
                rocket3Y = 77;
                rocketFrame3++;
            }
            // Reset the rockets back to 0
            if (level >= 16)
            {
                clearForTakeOff = false;
                lowerFirstPiece = false;
                deliveredFirstPiece = false;
                deliveredSecondPiece = false;
                level = 0;
                rocketFrame1 = 0;
                rocketFrame2 = 4;
                rocketFrame3 = 8;
                rocket1X = 422;
                rocket1Y = 443;
                rocket2X = 110;
                rocket2Y = 139;
                rocket3X = 510;
                rocket3Y = 75;
            }
        }
    }
}