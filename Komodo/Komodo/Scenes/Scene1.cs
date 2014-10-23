using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Interfaces;
using Komodo.Managers;

namespace Komodo
{
    class Scene1 :IScene
    {
        List<Tuple<EntityType, Vector2>> EntitiesForScene;
        //WIP - this variable is not used now but what it could be used for is hopefully apparent :)
        string SceneBackdrop;

        public Scene1()
        {
        EntitiesForScene = new List<Tuple<EntityType, Vector2>>();
        SceneBackdrop = "background";


        EntitiesForScene.Add(Tuple.Create(EntityType.Player, new Vector2(100,100)));
        EntitiesForScene.Add(Tuple.Create(EntityType.Enemy1, new Vector2(200,300)));
        //EntitiesForScene.Add(Tuple.Create(EntityType.Enemy2, new Vector2(300, 200)));
        EntitiesForScene.Add(Tuple.Create(EntityType.Metabolico, new Vector2(200, 400)));




        }

        public List<Tuple<EntityType, Vector2>> SceneEntities
        { get { return EntitiesForScene; } }
    }
}
