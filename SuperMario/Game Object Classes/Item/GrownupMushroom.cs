using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.MarioClass;

namespace SuperMario
{
    public class GrownupMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public bool HasBeenUsed { get; set; }
        public Vector2 Location { get; set; }

        public GrownupMushroom(Game1 game, Vector2 location)
        {
            MovingLeft = false;
            MyGame = game;
            Sprite = SpriteFactory.CreateGrowupMushroom();
            IsFalling = true;
            MyGame.Sprite = Sprite;
            HasBeenUsed = false;
            this.Location = location;
            
        }

        public void Update(GameTime GameTime)
        {
            //locationX++;
            if (Location.X - Camera.cameraPositionX < 0)
            {
                MovingLeft = !MovingLeft;
            }
            else if (Location.X - Camera.cameraPositionX > MyGame.GraphicsDevice.Viewport.Width - Sprite.Area(Location).Width)
            {
                MovingLeft = !MovingLeft;
            }

            if (MovingLeft)
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (IsFalling)
            {
                Location = new Vector2(Location.X, Location.Y + 3);
            }

            Sprite.Update(GameTime);
        }


        public Rectangle Area()
        {
            if (HasBeenUsed)
                return new Rectangle(0, 0, 0, 0);
            else
                return Sprite.Area(Location);
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.growupMushroomTexture);
            HasBeenUsed = true;
            if (MyGame.MarioSprite.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Small)
            {
                MyGame.MarioSprite.MarioBigState();
            }
            //MyGame.store.arrayOfSprites[5] = Sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));

        }
    }
}
