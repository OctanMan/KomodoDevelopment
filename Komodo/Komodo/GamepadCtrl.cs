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
    class GamepadCtrl : IController
    {
        private PlayerMind mPuppet;

        public GamepadCtrl()
        { }

        public PlayerMind SetControlledEntity
        {
            set { mPuppet = value; }
        }

       
        public void PollInput()
        {
            GamePadState gamePadState = GamePad.GetState(0);
            mPuppet.mindPos.X += gamePadState.ThumbSticks.Left.X * 5;
            mPuppet.mindPos.Y -= gamePadState.ThumbSticks.Left.Y * 5;


            if (gamePadState.DPad.Left == ButtonState.Pressed)
            {
                mPuppet.mindPos.X -= 5;
            }
            if (gamePadState.DPad.Right == ButtonState.Pressed)
            {
                mPuppet.mindPos.X += 5;
            }
            if (gamePadState.DPad.Up == ButtonState.Pressed)
            {
                mPuppet.mindPos.Y -= 5;
            }
            if (gamePadState.DPad.Down == ButtonState.Pressed)
            {
                mPuppet.mindPos.Y += 5;
            }





        }
    }
}
