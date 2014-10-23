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
    public abstract class AIMind:IEntityMind
    {
        private X2DToken mPossessedEntity;
        private int mOrientation;

        public AIMind(X2DToken pEntity)
        {
          
        }

        public virtual void UpdateMind()
        {

        }
    }
}
