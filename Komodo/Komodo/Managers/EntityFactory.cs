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
    public enum EntityType
    {
        Player,
        Metabolico,
        Enemy1,
        Enemy2,
    }

    public sealed class EntityFactory : IEntityFactory
    {
        IAIComponentManager mAIComponentManager;
        SpriteBatch sBatch;
        IServiceProvider mXService;
        X2DToken tempEntity;

       // public X2DToken NewEntity(EntityType Type, Vector2 pos, SpriteBatch sBatch, IServiceProvider xService)
        //{}

        public X2DToken TempEntity
        { get { return tempEntity; } }

        public EntityFactory(IServiceProvider xService, SpriteBatch pBatch, IAIComponentManager pAIManager)
        {
            mXService = xService;
            sBatch = pBatch;
            mAIComponentManager = pAIManager;
        }

        public void CreateEntity(EntityType Type, Vector2 pos)
        {
            X2DToken newEntity = null;
            VisualAsset Asset = null;

            switch (Type)
            {
                case EntityType.Player:
                    Asset = new VisualAsset(mXService);
                    Asset.loadAssets("UnicornSprite");
                    newEntity = new PlayerToken();
                    newEntity.DefaultProperties(Asset, sBatch, pos, mAIComponentManager, Type);
                    break;
                case EntityType.Metabolico:
                    Asset = new VisualAsset(mXService);
                    Asset.loadAssets("CarrotGuySprite");
                    newEntity = new MetabolicoToken();
                    newEntity.DefaultProperties(Asset, sBatch, pos, mAIComponentManager, Type);
                    break;
                case EntityType.Enemy1:
                    Asset = new VisualAsset(mXService);
                    Asset.loadAssets("CthulhuSprite");
                    newEntity = new Enemy1Token();
                    newEntity.DefaultProperties(Asset, sBatch, pos, mAIComponentManager, Type);
                    break;
                case EntityType.Enemy2:
                    Asset = new VisualAsset(mXService);
                    Asset.loadAssets("GhostGuySprite");
                    newEntity = new Enemy2Token();
                    newEntity.DefaultProperties(Asset, sBatch, pos, mAIComponentManager, Type);
                    break;

            }

            tempEntity = newEntity;

            //return newEntity;
        }
    }
}
