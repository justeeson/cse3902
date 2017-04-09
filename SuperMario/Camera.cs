using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Camera
    {
        public static int CameraPositionX;
        public static int CameraPositionY;
        public bool disableCamera = false;

        public Camera()
        {
            CameraPositionX = 0;
            CameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX)
        {
            if (!disableCamera)
            {
                if (MarioPositionX < Game1Utility.FinalLevelLocation)
                {
                    if (MarioPositionX > CameraPositionX + Game1Utility.CameraOffset)
                    {
                        CameraPositionX += MarioPositionX - (CameraPositionX + Game1Utility.CameraOffset);
                    }
                    else if (MarioPositionX < CameraPositionX + Game1Utility.CameraOffset && CameraPositionX > (CameraPositionX + Game1Utility.CameraOffset) - MarioPositionX)
                    {
                        CameraPositionX -= (CameraPositionX + Game1Utility.CameraOffset) - MarioPositionX;
                    }
                }
            }
        }
        
        public void SetPositionZero()
        {
            CameraPositionX = 0;
        }
    }
}
