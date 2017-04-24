using SuperMario.Interfaces;
using SuperMario.MarioClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMario.Levels;
using SuperMario.Command;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class FlagPole : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        private ICommand command;
        public FlagPole(Game1 game, Vector2 location)
        {
            this.MyGame = game;
            this.Sprite = SpriteFactory.CreateFlagPole();
            MyGame.Sprite = Sprite;
            this.Location = location;
        }
        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public async void BecomeUsed()
        {
            Game1.GetInstance.DisableControl = true;
            MyGame.PlayerStat.SetScoreValue(5000);
            MyGame.PlayerStat.SetEndGame(true);
            MarioWalkToCastleHandler obj = new MarioWalkToCastleHandler(MyGame, Location);
            this.Sprite = SpriteFactory.CreateFlagPoleToUsed();
            await Task.Delay(4000);
            new LevelGenerator();
            Game1.FileName = "Level1.xml";
            Game1.GetInstance.GameStatus = Game1.GameState.LivesScreen;
            command = new ResetCommand(Game1.GetInstance);
            command.Execute();
            
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
