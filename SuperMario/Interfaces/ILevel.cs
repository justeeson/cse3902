using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface ILevel
    {
        Game1 MyGame { get; set; }
        List<IItem> ItemList { get; set; }
        List<IEnemy> EnemyList { get; set; }
        List<IBlock> BlockList { get; set; }
        List<IBackground> BackgroundList { get; set; }

        void Load();
        void Reset();
        void Update(GameTime GameTime);
        void Draw(Vector2 location);
        void addFlower(Vector2 location);
        void addMushroom(Vector2 location);
        void addFireMushroom(Vector2 location);
        void addCoin(Vector2 location);
        void addStar(Vector2 location);
        void ReturnGround();
    }
}
