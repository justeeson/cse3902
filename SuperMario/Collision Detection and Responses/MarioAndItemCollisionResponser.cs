using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndItemCollisionResponser
    {
        public static void Response(IMario mario, IItem item)
        {
            item.UpdateCollision();
        }
    }
}
