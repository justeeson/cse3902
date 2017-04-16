using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface ILevel
    {
        Game1 MyGame { get; set; }
        Collection<IItem> ItemList { get;}
        Collection<IEnemy> EnemyList { get;}
        Collection<IBlock> BlockList { get;}
        IBlock[] BlockListLeftFacingOrder { get; }
        IBlock[] BlockListRightFacingOrder { get; }
        Collection<IBackground> BackgroundList { get;}

        void SortBlocksFacingRight(IBlock[] list);
        void SortBlocksFacingLeft(IBlock[] list);
        void Load();
        void Reset();
        void Update(GameTime GameTime);
        void Draw(Vector2 location);
        void addFlower(Vector2 location);
        void addMushroom(Vector2 location);
        void addFireMushroom(Vector2 location);
        void addCoin(Vector2 location);
        void addStar(Vector2 location);
        void addGodMushroom(Vector2 location);
        void ReturnGround();
    }
}
