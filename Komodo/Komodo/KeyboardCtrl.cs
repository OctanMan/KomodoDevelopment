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

namespace Komodo
{
    class KeyboardCtrl:IController
    {
        private PlayerMind
            mPuppet;

        public KeyboardCtrl()
        { }

        public PlayerMind SetControlledEntity
        {
            set { mPuppet = value; }
        }

        
        public void PollInput()
        { //here goes the code to check for key presses and (at least for now) change world position
           //Test code:
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D))
            mPuppet.mindPos.X += 5;
            if (keyboardState.IsKeyDown(Keys.A))
                mPuppet.mindPos.X -= 5;
            if (keyboardState.IsKeyDown(Keys.S))
                mPuppet.mindPos.Y += 5;
            if (keyboardState.IsKeyDown(Keys.W))
                mPuppet.mindPos.Y -= 5;

        }

    }
}
