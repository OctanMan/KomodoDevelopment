using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Komodo.Interfaces;

namespace Komodo.Managers
{

    enum ControllerType { Keyboard, Gamepad };

    class ControlManager
    {
        private static ControlManager mInstance;

        //Controllers
        private IController mController_1;

        //Entities to control
        private PlayerMind mEntityToControl_1 ;
        private PlayerMind mEntityToControl_2 ;


        //Used by Minds to get a reference of the player's token - could be mind?
        public X2DToken GetPlayerConrolledEntity
        { get { return mEntityToControl_1.myPlayerToken; } }
        

        //Get Singleton reference of ControlManager
        public static ControlManager Instance()
        {
          return mInstance;
        }


        public void ManagerSetup(ControlManager pSelf)
        {
            mInstance = pSelf;
            GamePadState padstate = GamePad.GetState(0);
            if (padstate.IsConnected)
            {
                CreateController(ControllerType.Gamepad);
            }
            else
            {
                CreateController(ControllerType.Keyboard);
            }
        }


        public void CreateCtrlContract(PlayerMind pControllableToken)
        {
            //No mechanism for now, just assign whatever entity asks to be controlled
            if (mEntityToControl_1 == null)
            {
                mEntityToControl_1 = pControllableToken;
                //Automatically assigns the first entity requesting a contract to a controller
                mController_1.SetControlledEntity = mEntityToControl_1;
            }
            else
            {   
                mEntityToControl_2 = pControllableToken;
            }
 
        }

        //Create a controller based on the passed type, T
        private void CreateController(ControllerType T)
        {
            switch(T)
            {
                case ControllerType.Keyboard:
                    {
                        mController_1 = new KeyboardCtrl();
                        break;
                    }
                case ControllerType.Gamepad:
                    {
                        mController_1 = new GamepadCtrl();
                        break;
                    }
                    
            }
            
        }


        public void UpdateInput()
        {
            mController_1.PollInput();
        }

    }
}
