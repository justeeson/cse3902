using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class FireMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public bool hasBeenUsed { get; set; }
        public Vector2 Location { get; set; }
        private float locationX;
        public FireMushroom(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateFireMushroom();
            MyGame.sprite = Sprite;
            hasBeenUsed = false;
            Location = location;
            locationX = Location.X;
        }

        public void Update(GameTime GameTime)
        {
            locationX++;
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
            this.Sprite = new CleanSprite(SpriteFactory.fireMushroomTexture);
            //MyGame.store.arrayOfSprites[3] = Sprite;
            MyGame.MarioSprite.MarioFireState();
            hasBeenUsed = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, new Vector2(locationX, Location.Y));
        }
    }
}
