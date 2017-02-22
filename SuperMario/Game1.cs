using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System;
using System.Collections;

namespace SuperMario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D texture { get; set; }
        private Texture2D background;
        public Texture2D enemies; // need to load the enemies somewhere
        private Rectangle mainFrame;
        public GameTime gameTime;
        public ObjectAndSpriteStore store;
        public SpriteFactory SpriteFactory;
        private ISprite Sprite;

      
        
        public ISprite sprite
        {
            get
            { return Sprite; }
            set
            { Sprite = value; }
        }

        private IMario mario;
        public IMario Mario
        {
            get
            { return mario; }
            set
            { mario = value; }
        }

        private IBlock block;
        public IBlock Block
        {
            get {return block; }
            set {block = value; }
        }

        private KeyboardController keyboardController;
        public KeyboardController KeyboardController
        {
            get
            { return keyboardController; }
            set
            { keyboardController = value; }
        }

        private GamepadController gamepadController;
        public GamepadController GamepadController
        {
            get
            { return gamepadController; }
            set
            { gamepadController = value; }
        }

      

        private static int xPos, yPos, xMax, yMax;
        
        private static ArrayList Valid_Keys;
        public static ArrayList validKeys
        {
            get
            { return Valid_Keys; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";         
        }

        protected override void Initialize()
        {
            Valid_Keys = ValidKeys.Instance.ArrayOfKeys();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("MarioSheet");
            background = Content.Load<Texture2D>("background");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Mario = new Mario(texture, 3, 12);

            SpriteFactory = new SpriteFactory();
            SpriteFactory.LoadAllTextures(Content);
            store = new ObjectAndSpriteStore(this);
            store.Initialize(this);
            block = new BlockLogic(this);

            KeyboardController = new KeyboardController();
            KeyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.Up, new MarioLookUpCommand(this));
            KeyboardController.RegisterCommand(Keys.Down, new MarioLookDownCommand(this));
            KeyboardController.RegisterCommand(Keys.Y, new MarioBecomeSmallCommand(this));

            //For final implementation use these keys to impleement jump, crouch, etc(use powerups for fire and big)
            KeyboardController.RegisterCommand(Keys.U, new MarioBecomeBigCommand(this));
            KeyboardController.RegisterCommand(Keys.I, new MarioBecomeFireCommand(this));
            KeyboardController.RegisterCommand(Keys.O, new MarioDeadCommand(this));

            KeyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            KeyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            KeyboardController.RegisterCommand(Keys.Z, new BlockQuestionBecomeUsedCommand(this));
            KeyboardController.RegisterCommand(Keys.X, new BlockBrickDisappearCommand(this));
            KeyboardController.RegisterCommand(Keys.C, new BlockHiddenBlockUsedCommand(this));

            GamepadController = new GamepadController();
            GamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLookLeftCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioLookRightCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MarioLookUpCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioLookDownCommand(this));

            //For final implementation use these keys to impleement jump, crouch, etc(use powerups for fire and big)
            GamepadController.RegisterCommand(Buttons.A, new MarioBecomeSmallCommand(this));
            GamepadController.RegisterCommand(Buttons.B, new MarioBecomeBigCommand(this));
            GamepadController.RegisterCommand(Buttons.X, new MarioBecomeFireCommand(this));


            xMax = GraphicsDevice.Viewport.Width;
            yMax = GraphicsDevice.Viewport.Height;
            xPos = xMax / 2;
            yPos = yMax / 2;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            KeyboardController.Update(gameTime);
            GamepadController.Update(gameTime);
            Mario.Update(gameTime);
            store.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainFrame, Color.White);
            spriteBatch.End();
            foreach (ISprite obj in store.arrayOfSprites)
            {
                obj.Draw(spriteBatch, new Vector2(xPos, yPos));
            }
            Mario.Draw(spriteBatch, new Vector2(xPos, yPos));
            base.Draw(gameTime);
        }
    }
}
