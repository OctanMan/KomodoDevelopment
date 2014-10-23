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

namespace Komodo.Interfaces
{
   public interface IAIComponentManager
    {
        //Create a Mind for the Entity that requests it
       IEntityMind CreateMind(X2DToken pEntity);

       //Create a Mind for the Player specifically - Has to be cotrolled by keyboard
       IEntityMind CreatePlayerMind(ControllableCharacter pCtrlChar);

       //Update the Minds in the Managers list - Mind Control!
       void MindControlUpdate();

    }

}
