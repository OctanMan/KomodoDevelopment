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
  public abstract class X2DToken
    {
        protected VisualAsset mAsset;
        protected Texture2D mEntTexture;
        protected SpriteBatch sBatch;
        public Vector2 worldPos;
        public EntityType eType;
        public bool isAlive = true;

        public virtual void DefaultProperties(VisualAsset pAsset, SpriteBatch pBatch, Vector2 pWorldPos, IAIComponentManager pAIManager, EntityType pType)
        {
            mAsset = pAsset;
            mEntTexture = pAsset.mTexture;
            sBatch = pBatch;
            worldPos = pWorldPos;
            eType = pType;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)worldPos.X, (int)worldPos.Y, mEntTexture.Width, mEntTexture.Height);
            }
        }

        public void DrawSelf(SpriteBatch pBatch)
        {
            //sBatch.Begin();
            pBatch.Draw(mEntTexture, worldPos, Color.White);
            //sBatch.End();
        }

    }
}
