﻿using System;
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
        public static Boolean StarStatus;
        private Boolean playSoundEffect;
        private int resetTimer;
        public static Boolean InvulnStatus;
        public static Boolean GroundedStatus;
        public static Boolean DisableJump;
        private int fireDelay;
        private Boolean fireStatus;
        public static Boolean RunStatus;
        private int yVelocity, yAcceleration;
        public static Boolean JumpStatus;
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
            command = new ResetCommand(Game1.GetInstance());
            Columns = columns;
            LocationX = (int)location.X;
            LocationY = (int)location.Y;
            starPowerTimer = 0;
            fireDelay = 0;
            fireStatus = false;
            invulnTimer = 0;
            yAcceleration = -1;
            resetTimer = 0;
            yVelocity = 0;
            JumpStatus = false;
            DisableJump = false;
            playSoundEffect = false;
            GroundedStatus = false;
            InvulnStatus = false;
            StarStatus = false;
            RunStatus = false;
        }

        public void setState()
        {
            State = StateMachine.GetState();
        }

        public int MarioMode()
        {
            return StateMachine.MarioMode;
        }

        public int Orientation()
        {
            return StateMachine.Orientation;
        }

        public void ResetVelocity()
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


        public void LookDown()
        {
            StateMachine.LookDown();
        }


        public void Dead()
        {
            StateMachine.Dead();
        }

        public bool isDead()
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
            if (Mario.JumpStatus == false && !isDead() && (Mario.DisableJump != true))
            {
                Game1Utility.MarioJumpSoundEffect.Play();
                yVelocity = 19;
                Mario.JumpStatus = true;
            }
        }

        public void Reset()
        {
            StateMachine.Reset();
            State = StateMachine.GetState();
            LocationX = 400;
            LocationY = 350;
        }

        public void Run()
        {
            RunStatus = true;
        }
        public void Update(GameTime GameTime)
        {
            setState();
            State.Update(GameTime);
            KeyboardState currentKeyboardState = Keyboard.GetState();
            if (StarStatus)
            {
                starPowerTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (starPowerTimer > 10000)
                {
                    StarPowerUp();
                }
            }
            if (fireStatus)
            {
                fireDelay += GameTime.ElapsedGameTime.Milliseconds;
                if (fireDelay > 500)
                {
                    fireStatus = false;
                    fireDelay = 0;
                }
            }
            if (InvulnStatus)
            {
                invulnTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (invulnTimer > 1800)
                {
                    Mario.InvulnStatus = false;
                    invulnTimer = 0;
                }
            }
            if (JumpStatus)
            {

                LocationY = LocationY - yVelocity;
                yVelocity = yVelocity + yAcceleration;
            }

            if (RunStatus)
            {
                KeyboardState newKeyboardState = Keyboard.GetState();
                GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);
                if (!(newKeyboardState.IsKeyDown(Keys.X)) && !newGamepadState.IsButtonDown(Buttons.B))
                {
                    RunStatus = false;
                }

            }

            if (!GroundedStatus && !JumpStatus)
            {
                DisableJump = true;
                Mario.LocationY += 5;
            }
            UpdateFireball(GameTime);

            if (LocationY >= Game1Utility.maxValueY)
            {
                resetTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (!playSoundEffect)
                {
                    MediaPlayer.Stop();
                    Game1Utility.DeathSoundEffect.Play();
                    playSoundEffect = true;
                }
                if (resetTimer > 3000)
                {
                    resetTimer -= 3000;
                    playSoundEffect = false;
                    MediaPlayer.Volume = Game1Utility.RegularVolume;
                    MediaPlayer.Play(Game1.GetInstance().BackgroundMusic);
                    command.Execute();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, new Vector2(LocationX - Camera.CameraPositionX, LocationY));
        }

        public void Fire()
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
                    if (aFireball.fire == false)
                    {
                        aCreateNew = false;
                        aFireball.MarioFire(StateMachine.Orientation, StateMachine.MarioMode, LocationX, LocationY);
                        break;
                    }
                }

                if (aCreateNew == true)
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

        private void UpdateFireball(GameTime GameTime)
        {
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                aFireball.Update(GameTime);
            }
        }

        public static void StarPowerUp()
        {
            if (StarStatus == false)
                StarStatus = true;
            else
            {
                StarStatus = false;
                MediaPlayer.Volume = Game1Utility.RegularVolume;
                MediaPlayer.Play(Game1.GetInstance().BackgroundMusic);
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