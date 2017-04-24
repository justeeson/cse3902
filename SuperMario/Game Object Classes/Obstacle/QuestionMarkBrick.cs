using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Blocks
{
    public class QuestionMarkBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public String itemObject { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }
        private bool hasBeenUsed;

        public QuestionMarkBrick(Game1 game, Vector2 location, String item)
        {
            MyGame = game;
            hasBeenUsed = false;
            Sprite = SpriteFactory.CreateQuestionMarkBrick();
            MyGame.Sprite = Sprite;
            this.Location = location;
            itemObject = item;
        }
        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
            if(!hasBeenUsed)
            {
               this.Location = new Vector2(Location.X+5, Location.Y);
                hasBeenUsed = true;
                switch (itemObject)
                {
                    case "coin":
                        MyGame.World.Level.addCoin(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "firemushroom":
                        MyGame.World.Level.addFireMushroom(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "flower":
                        MyGame.World.Level.addFlower(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "growmushroom":
                        MyGame.World.Level.addMushroom(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "star":
                        MyGame.World.Level.addStar(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "godMushroom":
                        MyGame.World.Level.addGodMushroom(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    case "drink":
                        MyGame.World.Level.addEnergyDrink(new Vector2(Location.X - 2, Location.Y - 30));
                        break;
                    default:
                        break;
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(Location.X - Camera.CameraPositionX, Location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
