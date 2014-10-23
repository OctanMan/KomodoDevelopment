using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Komodo.Interfaces;

namespace Komodo.Managers
{
    class AIComponentManager:IAIComponentManager
    {

        public List<IEntityMind> MindsControl = new List<IEntityMind>();
        MindFactory mindFactory = new MindFactory();

        public IEntityMind CreateMind(X2DToken pEntity)
        {
            //the AIMind is an abstract class for now
            mindFactory.CreateMind(pEntity);
            IEntityMind yourMind = mindFactory.TempMind;
            MindsControl.Add(yourMind);

            return yourMind;
        }


        //This is a method specifically for creating a PLAYER mind - this is different to a standard mind
        public IEntityMind CreatePlayerMind(ControllableCharacter pCtrlChar)
        { 
            IEntityMind yourMind = new PlayerMind(pCtrlChar);
            MindsControl.Add(yourMind);

            return yourMind;

        }

        public void MindControlUpdate()
        {
            foreach (IEntityMind M in MindsControl)
            {
                M.UpdateMind();
            }
        }
    }
}
