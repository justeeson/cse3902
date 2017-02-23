using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision
{

    [TestClass]
    public class CollisionTestLeft : IObject
    {
        public Rectangle Area { get; set; }


        public class LeftTest
        {
            public Rectangle Area { get; set; }
            public LeftTest(int X, int Y, int width, int height)
            {
                this.Area = new Rectangle(X, Y, width, height);
            }

        }
        [TestMethod()]
        public void TestLeft()
        {

            Rectangle collisionRectangle;
            LeftTest obj = new LeftTest(20, 16, 4, 8);
            LeftTest mario = new LeftTest(50, 80, 20, 40);
            for (int y = 0; y <= 30; y++)
            {
                mario.Area = new Rectangle(50-y, 80, 20, 40);
                collisionRectangle = Rectangle.Intersect(mario.Area, obj.Area);
                if (collisionRectangle.Left == obj.Area.Left && collisionRectangle.Width > collisionRectangle.Height)
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
