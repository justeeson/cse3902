using Microsoft.Xna.Framework;
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

namespace SuperMario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public Texture2D Texture { get; set; }
        private Texture2D background;
        public Boolean IsPaused;
        private Rectangle mainFrame;
        public GameTime GameTime;
        public SpriteFactory SpriteFactory;
        public Camera CameraPointer;
        private Song backgroundMusic;
        private Song pauseSoundEffect;
        private KeyboardState newKeyboardState;
        private KeyboardState oldKeyboardState;
        private static Game1 instance;
        public WorldManager World;
        public Vector2 Location { get; set; }
        public static List<MarioFireball> Mfireballs = new List<MarioFireball>();

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



        public static int XMax, YMax;
        public static ArrayList ValidKeysList
        { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
        }

        protected override void Initialize()
        {
            newKeyboardState = new KeyboardState();
            oldKeyboardState = new KeyboardState();
            ValidKeysList = ValidKeys.Instance.ArrayOfKeys();
            IsPaused = false;
            CameraPointer = new Camera();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            
            Texture = Content.Load<Texture2D>("MarioSheet");
            background = Content.Load<Texture2D>("background3");
            backgroundMusic = Content.Load<Song>("backgroundMusic");
            pauseSoundEffect = Content.Load<Song>("pauseSoundEffect");
            //MediaPlayer.IsRepeating = true;
            // MediaPlayer.Play(backgroundMusic);
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            SpriteFactory = new SpriteFactory();
            SpriteFactory.LoadAllTextures(Content);
            Block = new BlockLogic(this);
            Mario.LoadContent(Content);
            World = new WorldManager(this);
            World.Load();

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
            KeyboardController.RegisterCommand(Keys.N, new MarioGoToUndergroundCommand(this));

            GamepadController = new GamepadController();
            GamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLookLeftCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioLookRightCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioLookDownCommand(this));
            GamepadController.RegisterCommand(Buttons.A, new MarioJumpCommand(this));
            GamepadController.RegisterCommand(Buttons.B, new MarioRunCommand(this));

            XMax = GraphicsDevice.Viewport.Width;
            YMax = GraphicsDevice.Viewport.Height;
        }

        protected override void UnloadContent()
        {
        }

        public static Game1 GetInstance()
        {
            if (instance == null)
            {
                instance = new Game1();
            }
            return instance;
        }
        protected override void Update(GameTime GameTime)
        {
            newKeyboardState = Keyboard.GetState();
            if (newKeyboardState.IsKeyDown(Keys.P) && oldKeyboardState.IsKeyUp(Keys.P))
            {              
                IsPaused = !IsPaused;
                MediaPlayer.Play(pauseSoundEffect);
            }
            oldKeyboardState = newKeyboardState;
            if (!IsPaused)
            {
                this.GameTime = GameTime;
                KeyboardController.Update(GameTime);
                GamepadController.Update(GameTime);
                CameraPointer.UpdateX(Mario.LocationX);
                MarioSprite.Update(GameTime);
                World.Update(GameTime);
                Collision_Detection_and_Responses.CollisionHandling.Update(World.Level, this);
                base.Update(GameTime);
            }
        }

        protected override void Draw(GameTime GameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            World.Draw(Location);
            World.Draw(new Vector2(Camera.cameraPositionX, Camera.cameraPositionY));
            MarioSprite.Draw(SpriteBatch, new Vector2(Camera.cameraPositionX, Camera.cameraPositionY));
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                aFireball.Draw(SpriteBatch);
            }
            base.Draw(GameTime);
        } 
    }
}
