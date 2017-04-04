using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMario.Levels;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class WorldManager
    {
        public Game1 MyGame {get ; set;}
        public ILevel Level {get ; set;}

        public WorldManager(Game1 game)
        {
            MyGame = game;
            Level = new LevelClass(MyGame, "Level.xml");
        }
        public void Load()
        {
            Level.Load();
        }

        public void Reset()
        {
            Level.Reset();
        }

        public void Update(GameTime GameTime)
        {
            Level.Update(GameTime);

        }

        public void Draw(Vector2 location)
        {
            Level.Draw(location);
        }
    }
}
