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
    public class Enemy2Mind : AIMind, IEntityMind
    {
        private X2DToken mPossessedEntity;
        private int mOrientationY = 1;
        private int mOrientationX = 1;

        public Enemy2Mind(X2DToken pEntity) :base(pEntity)
        {
            mPossessedEntity = pEntity;
        }

        public void UpdateMind()
        {
            //http://stackoverflow.com/questions/7292870/per-pixel-collision-code-explanation
            //Some simple code for control the WorldPosition of the entity through their public member
            Vector2 mindpos = new Vector2(mPossessedEntity.worldPos.X, mPossessedEntity.worldPos.Y);
            mindpos.X += 1 * mOrientationX;
            mindpos.Y += 1 * mOrientationY;
            
 
            if (mindpos.Y >= 320 || mindpos.Y <= 0)
                mOrientationY = mOrientationY * -1;

            if (mindpos.X >= 700 || mindpos.X <= 0)
                mOrientationX = mOrientationX * -1;


            mPossessedEntity.worldPos.X = mindpos.X;
            mPossessedEntity.worldPos.Y = mindpos.Y;

        }

    }
}