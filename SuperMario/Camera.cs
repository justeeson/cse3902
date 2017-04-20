using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Camera
    {
        public static int CameraPositionX
        { get; set; }
        public static int CameraPositionY
        { get; set; }
        public bool DisableCamera
        { get; set; }

        public Camera()
        {
            DisableCamera = false;
            CameraPositionX = 0;
            CameraPositionY = 0;
        }

        public void UpdateX(int marioPositionX)
        {
            if (!DisableCamera)
            {
                if (marioPositionX < Game1Utility.FinalLevelLocation)
                {
                    if (marioPositionX > CameraPositionX + Game1Utility.CameraOffset)
                    {
                        CameraPositionX += marioPositionX - (CameraPositionX + Game1Utility.CameraOffset);
                    }
                    else if (marioPositionX < CameraPositionX + Game1Utility.CameraOffset && CameraPositionX > (CameraPositionX + Game1Utility.CameraOffset) - marioPositionX)
                    {
                        CameraPositionX -= (CameraPositionX + Game1Utility.CameraOffset) - marioPositionX;
                    }
                }
            }
        }
        
        public static void SetPositionZero()
        {
            CameraPositionX = 0;
        }
    }
}
