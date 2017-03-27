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
        public bool hasBeenUsed { get; set; }
        public Vector2 Location { get; set; }

        public GrownupMushroom(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateGrowupMushroom();
            MyGame.sprite = Sprite;
            hasBeenUsed = false;
            this.Location = location;
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public Rectangle Area()
        {
            if (hasBeenUsed)
                return new Rectangle(0, 0, 0, 0);
            else
                return Sprite.Area(Location);
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.growupMushroomTexture);
            hasBeenUsed = true;
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
