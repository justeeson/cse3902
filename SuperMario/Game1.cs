﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System.Collections;

namespace SuperMario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D texture { get; set; }
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

        //Gamepad is not used for this sprint but will be later
        /*private GamepadController gamepadController;
        public GamepadController GamepadController
        {
            get
            { return gamepadController; }
            set
            { gamepadController = value; }
        }*/

        private static ArrayList ListOfObjects;
        public static ArrayList listOfObjects
        {
            get
            { return ListOfObjects; }

            /*set
            { ListOfObjects = value; }*/
        }

        private static int xPos, yPos, xMax, yMax;
        
        private static ArrayList Valid_Keys;
        public static ArrayList validKeys
        {
            get
            { return Valid_Keys; }
            /*set
            { Valid_Keys = value; }*/
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
            Mario = new Mario(texture, 3, 12);

            SpriteFactory.Instance.LoadAllTextures(Content);
            ListOfObjects = ObjectArray.Instance.ArrayOfObjects(this);
            block = new BlockLogic(this);

            KeyboardController = new KeyboardController();
            KeyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.Up, new MarioJumpCommand(this));
            KeyboardController.RegisterCommand(Keys.Down, new MarioCrouchCommand(this));
            KeyboardController.RegisterCommand(Keys.Y, new MarioBecomeSmallCommand(this));
            KeyboardController.RegisterCommand(Keys.U, new MarioBecomeBigCommand(this));
            KeyboardController.RegisterCommand(Keys.I, new MarioBecomeFireCommand(this));
            KeyboardController.RegisterCommand(Keys.O, new MarioDeadCommand(this));
            KeyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            KeyboardController.RegisterCommand(Keys.R, new ResetCommand(this));

            KeyboardController.RegisterCommand(Keys.Z, new BlockQuestionBecomeUsedCommand(this));
            KeyboardController.RegisterCommand(Keys.X, new BlockBrickDisappearCommand(this));
            KeyboardController.RegisterCommand(Keys.C, new BlockHiddenBlockUsedCommand(this));


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
            KeyboardController.Update();
            Mario.Update();
            foreach (ISprite obj in ListOfObjects)
            {
                obj.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (ISprite obj in ListOfObjects)
            {
                obj.Draw(spriteBatch, new Vector2(xPos, yPos));
            }
            Mario.Draw(spriteBatch, new Vector2(xPos, yPos));
            base.Draw(gameTime);
        }
    }
}
