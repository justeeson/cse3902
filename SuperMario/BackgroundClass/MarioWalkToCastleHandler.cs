using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMario.MarioClass;

namespace SuperMario
{
    public class MarioWalkToCastleHandler
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public MarioWalkToCastleHandler(Game1 game, Vector2 location)
        {
            this.MyGame = game;
            game.MarioSprite =  new MarioWalkToCastleSprite(MyGame.Texture, 32, GetMarioStatus());
            game.World.Level.BlockList.Add(new FireworkClass(game, location));
            Update(MyGame.GameTime);
            Draw(MyGame.SpriteBatch, location);
            this.Location = location;
        }
        private string GetMarioStatus()
        {
            string result = "";
            if (MyGame.MarioSprite.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Small)
            {
                result = "small";
            }
            else if(MyGame.MarioSprite.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Big)
            {
                result = "big";
            }
            else
            {
                result = "fire";
            }
            return result;

        }
 
        public void Update(GameTime gameTime)
        {
            MyGame.MarioSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(Location.X - Camera.CameraPositionX, Location.Y);
            MyGame.MarioSprite.Draw(spriteBatch, location);
        }

    }
}
