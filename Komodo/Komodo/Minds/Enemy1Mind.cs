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
    public class Enemy1Mind:AIMind, IEntityMind
    {
        private X2DToken mPossessedEntity;
        private X2DToken PlayerToken;

        private int mOrientationY = 1;
        private int mOrientationX = 1;
        Vector2 mindpos;
        Vector2 Normalize;

        public Enemy1Mind(X2DToken pEntity) : base(pEntity)
        {
            mPossessedEntity = pEntity;
            PlayerToken = ControlManager.Instance().GetPlayerConrolledEntity;
        }

        public override void UpdateMind()
        {
            //http://stackoverflow.com/questions/7292870/per-pixel-collision-code-explanation
            //Some simple code for control the WorldPosition of the entity through their public member
          mindpos = new Vector2(mPossessedEntity.worldPos.X,mPossessedEntity.worldPos.Y);
          
          // mindpos.X += 1 * mOrientationX; // sets basic value of X 
          // mindpos.Y += 1 * mOrientationY; // sets basic value of Y

            /*if (mindpos.Y <= 0)
                mindpos.Y -= 1* mOrientationY;

            if (mindpos.Y <= 200)
                //mindpos.Y -= 1 * mOrientationY;
                mPossessedEntity.isAlive = false;*/

           if (mindpos.Y < 200)
           {
               mPossessedEntity.isAlive = false;
           }

           SeekingBehaviour();

        }

       

        public void SeekingBehaviour()
        {
            Vector2 playerPosition = PlayerToken.worldPos;

            Normalize = playerPosition - mindpos;
            Normalize.Normalize();
            mindpos += Normalize;

            mPossessedEntity.worldPos.X = mindpos.X;
            mPossessedEntity.worldPos.Y = mindpos.Y;

        }
    }
}
