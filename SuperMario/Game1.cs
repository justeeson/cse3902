using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D texture;
        public ISprite sprite;
        public IMario Mario;
        public IBlock Block;
        public KeyboardController keyboardController;
        public GamepadController gamepadController;
        public static int xPos, yPos, xMax, yMax;
        public static ContentManager game1Content;
        public static ArrayList listOfObjects;
        public static ArrayList validKeys;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
            game1Content = Content;
        }

        protected override void Initialize()
        {
            validKeys = ValidKeys.Instance.ArrayOfKeys(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("MarioSheet");
            Mario = new Mario(texture, 3, 12);

            SpriteFactory.Instance.LoadAllTextures(Content);
            listOfObjects = ObjectArray.Instance.ArrayOfObjects(this);
            Block = new BlockLogic(this);

            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            keyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            keyboardController.RegisterCommand(Keys.Up, new MarioJumpCommand(this));
            keyboardController.RegisterCommand(Keys.Down, new MarioCrouchCommand(this));
            keyboardController.RegisterCommand(Keys.Y, new MarioBecomeSmallCommand(this));
            keyboardController.RegisterCommand(Keys.U, new MarioBecomeBigCommand(this));
            keyboardController.RegisterCommand(Keys.I, new MarioBecomeFireCommand(this));
            keyboardController.RegisterCommand(Keys.O, new MarioDeadCommand(this));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));

            keyboardController.RegisterCommand(Keys.Z, new BlockQuestionBecomeUsedCommand(this));
            keyboardController.RegisterCommand(Keys.X, new BlockBrickDisappearCommand(this));
            keyboardController.RegisterCommand(Keys.C, new BlockHiddenBlockUsedCommand(this));


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
            keyboardController.Update();
            Mario.Update();
            foreach (ISprite obj in listOfObjects)
            {
                obj.Update(gameTime);

            }
            sprite.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (ISprite obj in listOfObjects)
            {
                obj.Draw(spriteBatch, new Vector2(xPos, yPos));
            }
            Mario.Draw(spriteBatch, new Vector2(xPos, yPos));
            base.Draw(gameTime);
        }
    }
}
