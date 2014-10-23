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

    public sealed class MindFactory : IMindFactory
    {

        //IAIComponentManager mAIComponentManager;
        public AIMind TempMind;
        // public X2DToken NewEntity(EntityType Type, Vector2 pos, SpriteBatch sBatch, IServiceProvider xService)
        //{}


        public void CreateMind(X2DToken pEntity)
        {
            AIMind newMind = null;

            switch (pEntity.eType)
            {
                case EntityType.Metabolico:
                    newMind = new Enemy1Mind(pEntity);
                    break;
                case EntityType.Enemy1:
                    newMind = new Enemy1Mind(pEntity);
                    break;
                case EntityType.Enemy2:
                    newMind = new Enemy2Mind(pEntity);
                    break;
            }

            TempMind = newMind;

        }
    }
}