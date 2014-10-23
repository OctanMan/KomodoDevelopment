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

namespace Komodo
{
    interface ISceneGraph
    {
        void calculateView();

        List<X2DToken> CompleteGraph
        {get;}

        void AppendToGraph(List<X2DToken> pList);

        void RemoveFromGraph(List<X2DToken> pList);

        List<X2DToken> Draw();

        //void updateList(List<X2DToken> pEntityList);
        //A list of entities to be processed/ rendered
    }
}
