using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class QuestionMarkBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }
        private bool hasBeenUsed;

        public QuestionMarkBrick(Game1 game, Vector2 location)
        {
            MyGame = game;
            hasBeenUsed = false;
            Sprite = SpriteFactory.CreateQuestionMarkBrick();
            MyGame.sprite = Sprite;
            this.Location = location;
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
                Random rnd = new Random();
                switch (rnd.Next(1, 6))
                {   
                    case 1:
                        MyGame.World.Level.addCoin(new Vector2(Location.X-3, Location.Y - 30));
                        break;
                    case 2:
                        MyGame.World.Level.addFireMushroom(new Vector2(Location.X - 3, Location.Y - 30));
                        break;
                    case 3:
                        MyGame.World.Level.addFlower(new Vector2(Location.X - 3, Location.Y - 30));
                        break;
                    case 4:
                        MyGame.World.Level.addMushroom(new Vector2(Location.X - 3, Location.Y - 30));
                        break;
                    case 5:
                        MyGame.World.Level.addStar(new Vector2(Location.X - 3, Location.Y - 30));
                        break;
                }
            }
        }
        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Location.X, this.Location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
