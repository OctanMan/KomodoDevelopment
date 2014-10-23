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
using Komodo.Managers;


namespace Komodo
{
    public class PlayerMind :AIMind,IEntityMind
    {
        private ControllableCharacter mPossessedPlayer;
        private ControlManager mControlManager;
        private int mOrientation = 1;
        
        //MindPos is updated by an IController in this class
        public Vector2 mindPos;

        public X2DToken myPlayerToken
        {
            get {return mPossessedPlayer; }
        }

        public PlayerMind(ControllableCharacter pEntity) :  base(pEntity)
        {
            mPossessedPlayer = pEntity;

            //Gets the control Manager
            mControlManager = ControlManager.Instance();
            //Requests to be controlled
            mControlManager.CreateCtrlContract(this);

           
        }

        public void UpdateMind()
        {
            //http://stackoverflow.com/questions/7292870/per-pixel-collision-code-explanation
            //Some simple code for control the WorldPosition of the entity through their public member

            //This 'Mind' for the player is designed to take command from and IController but positions are not committed until 
            //The position is run through these mind update methods

            mindPos = new Vector2(mPossessedPlayer.worldPos.X, mPossessedPlayer.worldPos.Y);
            mControlManager.UpdateInput();

            if (mindPos.X >= 680)
            {
                mindPos.X -= 6;
            }

            if (mindPos.X <= 6)
            {
                mindPos.X += 6;
            }

            if (mindPos.Y >= 355)
                mindPos.Y -= 6;

            if (mindPos.Y <= 0)
                mindPos.Y += 6;


            mPossessedPlayer.worldPos.Y = mindPos.Y;
            mPossessedPlayer.worldPos.X = mindPos.X;

           }

    }
}
