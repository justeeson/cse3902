using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Sprites;
using System.Timers;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using SuperMario.MarioClass;
using SuperMario.Command;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class Mario : IMario
    {
        public IMarioState State { get; set; }
        public Texture2D Texture { get; set; }
        public MarioStateMachine StateMachine { get; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public static int LocationX { get; set; }
        public static int LocationY { get; set; }
        public static bool StarStatus
        { get; set; }
        public static int EnergyStatus
        { get; set; }
        private bool playSoundEffect;
        private int resetTimer;
        private int energyTimer;
        private int godTimer;
        public static bool GodStatus
        { get; set; }
        public static bool InvulnStatus
        { get; set; }
        public static bool GroundedStatus
        { get; set; }
        public static bool DisableJump
        { get; set; }
        private int fireDelay;
        private bool fireStatus;
        public static bool RunStatus
        { get; set; }
        public static int yVelocity
        { get; set; }
        private int yAcceleration;
        public static bool JumpStatus
        { get; set; }
        private int invulnTimer;
        private int starPowerTimer;
        private static ContentManager mContentManager;
        private ICommand command;

        public Mario(Texture2D texture, int rows, int columns, Vector2 location)
        {
            State = new StandingRightSmallMarioState(this);
            Texture = texture;
            StateMachine = new MarioStateMachine(this);
            Rows = rows;
            command = new ResetCommand(Game1.GetInstance);
            Columns = columns;
            LocationX = (int)location.X;
            LocationY = (int)location.Y;
            starPowerTimer = 0;
            energyTimer = 0;
            fireDelay = 0;
            fireStatus = false;
            invulnTimer = 0;
            yAcceleration = -1;
            resetTimer = 0;
            yVelocity = 0;
            godTimer = 0;
            EnergyStatus = 1;
            JumpStatus = false;
            DisableJump = false;
            playSoundEffect = false;
            GroundedStatus = false;
            InvulnStatus = false;
            StarStatus = false;
            RunStatus = false;          
            GodStatus = false;
        }

        public void SetState()
        {
            State = StateMachine.GetState;
        }

        public int MarioMode()
        {
            return StateMachine.MarioMode;
        }

        public int Orientation()
        {
            return StateMachine.Orientation;
        }

        public static void ResetVelocity()
        {
            yVelocity = 0;
        }

        public void LookLeft()
        {
            StateMachine.LookLeft();
        }

        public void LookRight()
        {
            StateMachine.LookRight();
        }

        public static String LivesRemaining()
        {
            String totalLives = Game1Utility.MarioTotalLives + "";
            return totalLives;
        }

        public void LookDown()
        {
            StateMachine.LookDown();
        }


        public void Dead()
        {
            StateMachine.Dead();
        }

        public bool IsDead()
        {
            return StateMachine.Orientation == (int)MarioStateMachine.Orientations.Dead;
        }

        public void MarioBigState()
        {
            StateMachine.MarioBigState();
        }

        public void MarioSmallState()
        {
            StateMachine.MarioSmallState();
        }

        public void MarioFireState()
        {
            StateMachine.MarioFireState();
        }

        public void Jump()
        {
            if (!Mario.JumpStatus && !IsDead() && (!Mario.DisableJump))
            {
                Game1Utility.MarioJumpSoundEffect.Play();
                yVelocity = 19;
                Mario.JumpStatus = true;
            }
        }

        public void Reset()
        {
            StateMachine.Reset();
            State = StateMachine.GetState;
            LocationX = 400;
            LocationY = 350;
        }

        public void Run()
        {
            RunStatus = true;
        }
        public void Update(GameTime gameTime)
        {
            SetState();
            State.Update(gameTime);
            if((Game1.GetInstance.MouseState.X > (LocationX - Camera.CameraPositionX)) && Game1.GetInstance.MouseControl)
            {
                (new MarioLookRightCommand(Game1.GetInstance)).Execute();
            }

            else if ((Game1.GetInstance.MouseState.X < (LocationX + Camera.CameraPositionX)) && Game1.GetInstance.MouseControl)
            {
                (new MarioLookLeftCommand(Game1.GetInstance)).Execute();
            }

            if (LocationX <= 0)
            {
                LocationX = 0;
            }
            if (StarStatus)
            {
                starPowerTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (starPowerTimer > 10000)
                {
                    StarPowerUp();
                    starPowerTimer = 0;
                }
            }

            if(Mario.EnergyStatus == 2)
            {
                energyTimer += gameTime.ElapsedGameTime.Milliseconds;
                if(energyTimer > 6000)
                {
                    Mario.EnergyStatus = 1;
                    energyTimer = 0;                }
            }
            if (fireStatus)
            {
                fireDelay += gameTime.ElapsedGameTime.Milliseconds;
                if (fireDelay > 500)
                {
                    fireStatus = false;
                    fireDelay = 0;
                }
            }
            if (InvulnStatus)
            {
                invulnTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (invulnTimer > 1800)
                {
                    Mario.InvulnStatus = false;
                    invulnTimer = 0;
                }
            }
            if (JumpStatus || !GroundedStatus)
            {
                LocationY = LocationY - yVelocity;
                yVelocity = yVelocity + yAcceleration;
            }

            if (GodStatus)
            {
                godTimer += gameTime.ElapsedGameTime.Milliseconds;
                if(godTimer > 10000)
                {
                    Mario.GodStatus = false;
                    godTimer = 0;
                }
            }
            if (RunStatus)
            {
                KeyboardState newKeyboardState = Keyboard.GetState();
                GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);
                MouseState mouseState = Game1.GetInstance.MouseState;
                if (!(newKeyboardState.IsKeyDown(Keys.X)) && !newGamepadState.IsButtonDown(Buttons.B) && !(mouseState.LeftButton == ButtonState.Pressed))
                {
                    RunStatus = false;
                }

            }

            if (!GroundedStatus && !JumpStatus)
            {
                DisableJump = true;
            }
            UpdateFireball(gameTime);

            if (LocationY >= Game1Utility.MaxValueY)
            {
                resetTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (!playSoundEffect)
                {
                    MediaPlayer.Stop();
                    Game1Utility.DeathSoundEffect.Play();
                    Game1.GetInstance.DisableControl = true;
                    playSoundEffect = true;
                    Game1Utility.MarioTotalLives--;
                }
                if (resetTimer > 3000)
                {
                    resetTimer -= 3000;
                    playSoundEffect = false;
                    command.Execute();
                    if (Game1Utility.MarioTotalLives == 0)
                    {
                        Game1.GetInstance.GameStatus = Game1.GameState.End;
                    }
                    else
                    {
                        Game1.GetInstance.GameStatus = Game1.GameState.LivesScreen;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location);
        }

        public void ThrowFire()
        {
            if(StateMachine.MarioMode != (int)MarioStateMachine.MarioModes.Fire)
            {
                return;
            }

            if (!fireStatus)
            {
                bool aCreateNew = true;
                foreach (MarioFireball aFireball in Game1.Mfireballs)
                {
                    if (!aFireball.Fire)
                    {
                        aCreateNew = false;
                        aFireball.MarioFire(StateMachine.Orientation, StateMachine.MarioMode, LocationX, LocationY);
                        break;
                    }
                }

                if (aCreateNew)
                {
                    MarioFireball aFireball = new MarioFireball();
                    aFireball.LoadContent(mContentManager);
                    Game1.Mfireballs.Add(aFireball);
                    aFireball.MarioFire(StateMachine.Orientation, StateMachine.MarioMode, LocationX, LocationY);
                }
                fireStatus = true;
            }
        }

        public static void LoadContent(ContentManager theContentManager)
        {
            mContentManager = theContentManager;
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                aFireball.LoadContent(theContentManager);
            }
        }

        private static void UpdateFireball(GameTime gameTime)
        {
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                aFireball.Update(gameTime);
            }
        }

        public static void StarPowerUp()
        {
            if (!StarStatus)
                StarStatus = true;
            else
            {
                StarStatus = false;
                MediaPlayer.Play(Game1.GetInstance.BackgroundMusic);
            }
        }

        public static void Invulnerability()
        {

            InvulnStatus = true;

        }

        public Rectangle Area() 
        {
            if (StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Small)
                return new Rectangle(LocationX + 12, LocationY + 27, 26, 33);
            else
                return new Rectangle(LocationX + 10, LocationY + 1, 31, 65);
        }
    }
}