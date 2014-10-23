using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Komodo.Interfaces;
using Komodo.Managers;

namespace Komodo
{
    class SceneManager:ISceneManager
    {
        //These resources allow the SceneManager to do it's job:

        //Create or Terminate entities
        private IEntityManager mEntityManager;
        //Store entities that are in the scene
        private ISceneGraph mSceneGraph;
        //Check for collisions in the scene
        private ICollisionManager mCollsionManager;
        
        //For adding and removing entities - will need some way of passing required entity data

        //Entities to add to the scene this update
        private List<X2DToken> mEntitiesToAdd;
        //Entities to remove from the scene this update
        private List<X2DToken> mEntitiesToRemove = new List<X2DToken>();

        
        
        public SceneManager()
        {
            //Create a New SceneGraph to use for scene info
            mSceneGraph = new SceneGraph();
        }


        public void ManagerSetup(IEntityManager pEntityManager, ICollisionManager pCollisionManager)
        {
            mEntityManager = pEntityManager;
            mCollsionManager = pCollisionManager;
            
        }

        public void NewScene()
        {
            //WIP Scene Import
            IScene TestScene = new Scene1();

            //Adding entities to a specfic scene will be needed in initialisation but specifics of WHAT to add will need to be worked on
            AddEntitiesToScene(TestScene.SceneEntities);
        }

        //Get new entities in the scene - request creation and return updated reference list
        private void AddEntitiesToScene(List<Tuple<EntityType, Vector2>> pEntityProperties)
        {
            mEntitiesToAdd = mEntityManager.AddNewEntities(pEntityProperties);
        }

        //Remove (dead?) entities from the scene - request termination
        private void RemoveEntitiesFromScene()
        { 
            //check which entities are marked for termination and add them to a list
            //mEntitiesToRemove.Remove(DeadEntity); - WIP
            foreach (X2DToken T in mSceneGraph.CompleteGraph)
            {
                if (T.isAlive == false)
                {
                    mEntitiesToRemove.Add(T);
                }
            }
           // mEntityManager.RemoveEntitiesFromList(mEntitiesToRemove);
        }


        //Update the SceneManagers view of objects in the scene (on and off camera)
        public void UpdateSceneSnapshot()
        {
            //update stuff();

            //Check for Collisions in the scene
            //As long as there are two or more entities in the scene - pass them to be checked for collissions
            if(mSceneGraph.CompleteGraph.Count >= 2)
            {
                mCollsionManager.EntityList(mSceneGraph.CompleteGraph);
            }

            //As a result of Scene activity...

            //Add Entities to Scene...

            //...then place on SceneGraph
            mSceneGraph.AppendToGraph(mEntitiesToAdd);
            mEntitiesToAdd.Clear();

            //mSceneGraph.updateList(pEntityList);
            //return pEntityList;

            //And remove entities from the Scene

            //First from the SceneGraph
            RemoveEntitiesFromScene();
            mSceneGraph.RemoveFromGraph(mEntitiesToRemove);
            mEntitiesToRemove.Clear();
        }
            

        //Returns entities visible on the SceneGrpah
        //Only the SceneManager should have access
        public List<X2DToken> EntitiesToDraw ()
        {
            return mSceneGraph.Draw();   
        }
    }
}
