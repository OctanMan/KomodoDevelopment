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
    public class ControllableCharacter:X2DToken
    {
        ControlManager mControlManager;
        IEntityMind myPlayerMind;

        public void RevokeControl()
        {
            //Mechanism for revoking player control - eg, switching characters
        }

         public override void DefaultProperties(VisualAsset pAsset, SpriteBatch pBatch, Vector2 pWorldPos, IAIComponentManager pAIManager, EntityType pType)
        {
               //Gets the control Manager
            //mControlManager = ControlManager.Instance();
            //Requests to be controlled
            //mControlManager.CreateCtrlContract(this);


             //Get a specific PlayerMind
            myPlayerMind = pAIManager.CreatePlayerMind(this);

           base.DefaultProperties(pAsset, pBatch, pWorldPos, pAIManager, pType);
        }

     

    }
}
