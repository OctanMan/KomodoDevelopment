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

    class Enemy1Token : Character
    {

        IEntityMind myMind;

        //INTENTION TO SEPERATE CREATION FROM INITIALISATION BY HAVING THE FACTORY CALL THE DEFAULTPROPERTIES() METHOD 
        public Enemy1Token()
        {

        }

        public override void DefaultProperties(VisualAsset pAsset, SpriteBatch pBatch, Vector2 pWorldPos, IAIComponentManager pAIManager, EntityType pType)
        {
            base.DefaultProperties(pAsset, pBatch, pWorldPos, pAIManager, pType);
            myMind = pAIManager.CreateMind(this);
            
            
        }

        public void enemyCollide()
        {
            this.worldPos.Y -= 100;

        }

        public void pickupCollide()
        {


        }


    }
}
