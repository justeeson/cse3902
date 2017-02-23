using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision
{

    [TestClass]
    public class CollisionTestTop : IObject
    {
        public Rectangle Area { get; set; }

        public class TopTest
        {
            public Rectangle Area { get; set; }

            public TopTest(int X, int Y, int width, int height)
            {
                this.Area = new Rectangle(X, Y, width, height);
            }

        }
        [TestMethod()]
        public void TestTop()
        {

            Rectangle collisionRectangle;
            TopTest obj = new TopTest(100, 50, 4, 8);
            TopTest mario = new TopTest(50, 100, 20, 40);
            for (int y = 0; y < 50; y++)
            {
                mario.Area = new Rectangle(100, 100 - y, 20, 40);
                collisionRectangle = Rectangle.Intersect(mario.Area, obj.Area);
                if (collisionRectangle.Top == obj.Area.Top && collisionRectangle.Width > collisionRectangle.Height)
                {

                }
                else
                {
                    Assert.Fail();
                }
            }
        }

    }
}
