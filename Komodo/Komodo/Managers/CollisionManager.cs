using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Komodo.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Komodo.Managers;


namespace Komodo.Managers
{
    class CollisionManager : ICollisionManager
    {
        CollisionAlarm pAlarm;

        public CollisionManager(CollisionAlarm cAlarm)
        {
            pAlarm = cAlarm;
            pAlarm.CollisionEvent += new CollisionAlarm.CollisionEventHandler(processCollision);
        }


        X2DToken[] temp;
        public void EntityList(List<X2DToken> pEntityList)
        {
            
            /*foreach (X2DToken T in pEntityList)
            {
                if (T.worldPos.Y >= 360)
                {
                    T.worldPos.Y -= 50;
                }
                if (T.worldPos.Y >= -360)
                {
                    T.worldPos.Y += 50;
                }
            }*/
            temp = pEntityList.ToArray();

            for(int i = 0; i < temp.Length; i++)
            {
                for (int j = i+1; j < temp.Length; j++)
                {

                   
                   checkCollision(temp[i], temp[j]);
                }
            }
        }

        public void checkCollision(X2DToken E1, X2DToken E2)
        {

            if (E1.BoundingBox.Intersects(E2.BoundingBox))
            {
                pAlarm.pCollision(E1, E2);
            }

        }

        public void processCollision(object sender, CollisionEventArgs ce)
        {
            //P1 = metabolico (Check his collision first)
            if ((ce.P1.eType == EntityType.Metabolico && ce.P2.eType == EntityType.Player) || (ce.P2.eType == EntityType.Metabolico && ce.P1.eType == EntityType.Player))
            {
                ce.P1.worldPos.Y += 10;
                //ce.p2.isAlive = false;
                
            }
            else if ((ce.P1.eType == EntityType.Metabolico && ce.P2.eType == EntityType.Enemy1) || (ce.P2.eType == EntityType.Metabolico && ce.P1.eType == EntityType.Enemy1))
            {
                ce.P1.worldPos.Y += 10;
            }
            else if ((ce.P1.eType == EntityType.Metabolico && ce.P2.eType == EntityType.Enemy2) || (ce.P2.eType == EntityType.Metabolico && ce.P1.eType == EntityType.Enemy2))
            {
                ce.P1.worldPos.Y += 10;
            }

            // P1 = enemy 2
            else if ((ce.P1.eType == EntityType.Enemy2 && ce.P2.eType == EntityType.Player) || (ce.P2.eType == EntityType.Enemy2 && ce.P1.eType == EntityType.Player))
            {
                ce.P1.worldPos.X += 10;
                ce.P2.worldPos.Y -= 10;
            }
            else if ((ce.P1.eType == EntityType.Enemy2 && ce.P2.eType == EntityType.Enemy1) || (ce.P2.eType == EntityType.Enemy2 && ce.P1.eType == EntityType.Enemy1))
            {
                ce.P1.worldPos.Y += 10;
                
            }

            //P1 = enemy 1
            else if ((ce.P1.eType == EntityType.Enemy1 && ce.P2.eType == EntityType.Player) || (ce.P2.eType == EntityType.Enemy1 && ce.P1.eType == EntityType.Player))
            {
                ce.P1.worldPos.Y += 10;
            }
            //Player collision is handled all before this


        }
    }
}

