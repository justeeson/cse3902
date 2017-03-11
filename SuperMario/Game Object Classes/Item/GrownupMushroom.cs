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
    public class GrownupMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Location { get; set; }

        public GrownupMushroom(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateGrowupMushroom();
            MyGame.sprite = Sprite;
            Rectangle = new Rectangle(300, 160, 4, 8);
            this.Location = location;
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public Rectangle Area()
        {
            return Rectangle;
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.growupMushroomTexture);
            this.Rectangle = new Rectangle();
            if (Mario.MarioMode == (int)Mario.MarioModes.Small)
            {
                MyGame.MarioSprite.MarioBigState();
            }
            //MyGame.store.arrayOfSprites[5] = Sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, Location);
        }
    }
}
