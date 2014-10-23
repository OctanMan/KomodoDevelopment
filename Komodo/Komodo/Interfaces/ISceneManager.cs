using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Komodo.Interfaces;

namespace Komodo
{
    interface ISceneManager
    {
        void ManagerSetup(IEntityManager pEntityManager, ICollisionManager pCollisionManager);

        void NewScene();

        void UpdateSceneSnapshot();

        //List<X2DToken> updateList(List<X2DToken> pAssetList);

        List<X2DToken> EntitiesToDraw();
    }
}
