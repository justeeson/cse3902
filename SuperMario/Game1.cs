using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Interfaces;
using SuperMario.Sprites;

namespace SuperMario
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D texture;
        public ISprite sprite;
        public Mario Mario;
        public KeyboardController keyboardController;
        public GamepadController gamepadController;
        public static int xPos, yPos, xMax, yMax;
        public static ContentManager game1Content;
        private Turtle turtleObject;
        private Flower flowerObject;
        private Coin coinObject;
        private GrownupMushroom grownupMushroomObject;
        private FireMushroom fireMushroomObject;
        private Star starObject;
        private NormalMonster normalMonsterObject;
        //private SolidBrick solidBrickObject;
        private SolidBrickWithCrews solidBrickWithCrewsObject;
        private QuestionMarkBrick questionMarkBrickObject;
        private BreakableHorizontalBrick breakableHorizontalBrickObject;
        private BreakableCurlyBrick breakableCurlyBrickObject;
        private Pipe pipeObject;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
            game1Content = Content;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("smallMario");
            //sprite = new Mario(texture, 1, 12);
            Mario = new Mario(texture, 1, 12);


            //Declare the controllers and register the commands
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            keyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            /*
            keyboardController.RegisterCommand(Keys.E, new NonMovingAnimatedMarioCommand(this));
            keyboardController.RegisterCommand(Keys.R, new MovingNonAnimatedMarioCommand(this));
            keyboardController.RegisterCommand(Keys.T, new MovingAnimatedMarioCommand(this));

            gamepadController = new GamepadController();
            gamepadController.RegisterCommand(Buttons.A, new NonMovingNonAnimatedMarioCommand(this));
            gamepadController.RegisterCommand(Buttons.B, new NonMovingAnimatedMarioCommand(this));
            gamepadController.RegisterCommand(Buttons.X, new MovingNonAnimatedMarioCommand(this));
            gamepadController.RegisterCommand(Buttons.Y, new MovingAnimatedMarioCommand(this));
            */
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
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
                Exit();
                */
            keyboardController.Update();

           // gamepadController.Update();
            
            Mario.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sprite.Draw(spriteBatch, new Vector2(xPos, yPos));
            base.Draw(gameTime);
        }
    }
}
