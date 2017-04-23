using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class Game1 : Game
    {
        public SpriteBatch SpriteBatch
        { get; set; }
        public Texture2D Texture { get; set; }
        public GameTime GameTime
        { get; set; }
        public Camera CameraPointer
        { get; set; }
        private int continueTimer;
        public Song BackgroundMusic
        { get; set; }
        public bool MouseControl
        { get; set; }
        private SoundEffect pauseSoundEffect;
        private bool playSound;
        private GamePadState newGamepadState;
        private KeyboardState newKeyboardState;
        public static bool EndGameStatus
        { get; set; }
        private KeyboardState oldKeyboardState;
        private GamePadState oldGamepadState;
        public bool DisableControl
        { get; set; }
        private static Game1 instance;
        public MouseState MouseState
        { get; set; }
        private Texture2D blackHole;
        public WorldManager World
        { get; set; }
        public PlayerStatistic PlayerStat
        { get; set; }
        public Vector2 Location { get; set; }
        private static Collection<MarioFireball> fireballList;
        public static Collection<MarioFireball> Mfireballs
        { get { return fireballList; } }
        public enum GameState
        {
            LivesScreen,
            Playing,
            Pause,
            End
        }

        public GameState GameStatus
        { get; set; }

        public ISprite Sprite
        { get; set; }
        
        public IProjectile Fireball
        { get; set; }
        public IMario MarioSprite
        { get; set; }

        public IBlock Block
        { get; set; }
        public KeyboardController KeyboardController
        { get; set; }

        public GamepadController GamepadController
        { get; set; }

        public MouseController MouseController
        { get; set; }

        public Game1()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
        }

        protected override void Initialize()
        {
            Game1Utility.Initialize();
            Game1Utility.LoadContent();
            fireballList = new Collection<MarioFireball>();
            newKeyboardState = new KeyboardState();
            oldKeyboardState = new KeyboardState();
            MouseState = new MouseState();      
            DisableControl = false;
            continueTimer = 0;
            EndGameStatus = false;
            IsMouseVisible = false;
            MouseControl = false;
            playSound = false;
            GameStatus = GameState.LivesScreen;
            CameraPointer = new Camera();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            
            Texture = Content.Load<Texture2D>("MarioSheet");
            BackgroundMusic = Content.Load<Song>("backgroundMusic");
            pauseSoundEffect = Content.Load<SoundEffect>("pauseSoundEffect");
            blackHole = Content.Load<Texture2D>("blackholeSprite");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.6f;
            SpriteFactory.LoadAllTextures(Content);
            Block = new BlockLogic(this);
            Mario.LoadContent(Content);
            World = new WorldManager(this);
            World.Load();
            PlayerStat = new PlayerStatistic(SpriteBatch, Content);
               
            // This is a temp location, the following command needs to be relocated
            new LevelGenerator();

            KeyboardController = new KeyboardController();
            KeyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.Down, new MarioLookDownCommand(this));
            KeyboardController.RegisterCommand(Keys.A, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.D, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.S, new MarioLookDownCommand(this));
            KeyboardController.RegisterCommand(Keys.Z, new MarioJumpCommand(this));
            KeyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            KeyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            KeyboardController.RegisterCommand(Keys.X, new MarioRunCommand(this));
            
            GamepadController = new GamepadController();
            GamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLookLeftCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioLookRightCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioLookDownCommand(this));
            GamepadController.RegisterCommand(Buttons.X, new ResetCommand(this));
            GamepadController.RegisterCommand(Buttons.A, new MarioJumpCommand(this));
            GamepadController.RegisterCommand(Buttons.B, new MarioRunCommand(this));

            MouseController = new MouseController();
            MouseController.RegisterCommand("LeftMouseClick", new MarioRunCommand(this));
            MouseController.RegisterCommand("RightMouseClick", new MarioJumpCommand(this));
            MouseController.RegisterCommand("MiddleMouseClick", new MarioLookDownCommand(this));
        }

        protected override void UnloadContent()
        {
        }
        public static Game1 GetInstance
        {
            get { if (instance == null) return new Game1();
                else return instance; }
        }
        protected override void Update(GameTime gameTime)
        {
            newKeyboardState = Keyboard.GetState();
            newGamepadState = GamePad.GetState(PlayerIndex.One);
            MouseState = Mouse.GetState();          
            if ((newKeyboardState.IsKeyDown(Keys.P) && oldKeyboardState.IsKeyUp(Keys.P)) ||
                newGamepadState.IsButtonDown(Buttons.Start) && oldGamepadState.IsButtonUp(Buttons.Start))
            {   
                if(GameStatus == GameState.Pause)
                {
                    MediaPlayer.Resume();
                    GameStatus = GameState.Playing;
                    pauseSoundEffect.Play();
                }           
                else if(GameStatus == GameState.Playing)
                {
                    
                    MediaPlayer.Pause();
                    GameStatus = GameState.Pause;
                    pauseSoundEffect.Play();
                }
            }

            if ((newKeyboardState.IsKeyDown(Keys.M) && oldKeyboardState.IsKeyUp(Keys.M)))
            {
                MouseControl = !MouseControl;
                IsMouseVisible = !IsMouseVisible;
            }

            oldKeyboardState = newKeyboardState;
            oldGamepadState = newGamepadState;
            if (GameStatus == GameState.Playing)
            {
                this.GameTime = gameTime;
                if (!DisableControl)
                {
                    KeyboardController.Update();
                    GamepadController.Update();
                    MouseController.Update();
                    CameraPointer.UpdateX(Mario.LocationX);
                }
                MarioSprite.Update(gameTime);
                World.Update(gameTime);
                Collision_Detection_and_Responses.CollisionHandling.Update(World.Level, this);
                PlayerStat.Update(gameTime);
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if ((GameStatus == GameState.Playing) || (GameStatus == GameState.Pause))
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                World.Draw(Location);
                World.Draw(new Vector2(Camera.CameraPositionX, Camera.CameraPositionY));
                MarioSprite.Draw(SpriteBatch, new Vector2(Mario.LocationX - Camera.CameraPositionX, Mario.LocationY));
                PlayerStat.Draw(new Vector2(Camera.CameraPositionX, Camera.CameraPositionY));

                foreach (MarioFireball aFireball in Game1.Mfireballs)
                {
                    aFireball.Draw(SpriteBatch);
                }
                if (Mario.GodStatus)
                {
                    SpriteBatch.Begin();
                    SpriteBatch.Draw(blackHole, new Vector2(MouseState.X - 20, MouseState.Y - 20), Color.White);
                    SpriteBatch.End();
                }
                base.Draw(gameTime);
            }

            else if(GameStatus == GameState.LivesScreen)
            {
                DisableControl = true;
                MediaPlayer.Stop();
                continueTimer += gameTime.ElapsedGameTime.Milliseconds;
                if(continueTimer > 2500)
                {
                    continueTimer -= 2500;
                    GameStatus = GameState.Playing;
                    MediaPlayer.Play(BackgroundMusic);
                    DisableControl = false;
                }
                GraphicsDevice.Clear(Color.Black);
                PlayerStat.Draw(new Vector2(Camera.CameraPositionX, Camera.CameraPositionY));
                MarioSprite.Draw(SpriteBatch, new Vector2(250, 200));
            }

            else if(GameStatus == GameState.End)
            {
                DisableControl = true;
                MediaPlayer.Stop();
                if (!playSound)
                {
                    Game1Utility.GameOverSoundEffect.Play();
                    playSound = true;
                }
                GraphicsDevice.Clear(Color.Black);
                PlayerStat.Draw(new Vector2(Camera.CameraPositionX, Camera.CameraPositionY));
            }
        } 
    }
}
