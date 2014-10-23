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
using Komodo.Managers;

namespace Komodo.Interfaces
{
    interface IEntityManager
    {
        void ManagerSetup(IServiceProvider xServices, SpriteBatch pBatch, IAIComponentManager aiManager);

        //Make new requested entities Method
        List<X2DToken> AddNewEntities(List<Tuple<EntityType, Vector2>> pEntitiesData);

        //Remove requested entities Method
        //List<X2DToken> RemoveEntities();

        //void drawEntity();

        void updateList();

      //  void RemoveEntitiesFromList(List<X2DToken> rList);

        //Remove entity Method
        //void RemoveEntity();


    }
}
