using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komodo
{
    public class CollisionEventArgs : EventArgs
    {
        //The 'collisonEventArgs' defined here and seen below provide a single variable for passing the parameters of the event: 2 X2DTokens
        public CollisionEventArgs(X2DToken E1, X2DToken E2)
        {
            P1 = E1;
            P2 = E2;

        }
        public X2DToken P1;
        public X2DToken P2;
    }

    public class CollisionAlarm
    {
        public delegate void CollisionEventHandler(object sender, CollisionEventArgs ce);

        public event CollisionEventHandler CollisionEvent;

        public void pCollision(X2DToken E1, X2DToken E2)
        {
            CollisionEventArgs collisionArgs = new CollisionEventArgs(E1, E2);

            CollisionEvent(this, collisionArgs);
        }
    }
}
