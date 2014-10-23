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
using Komodo.Managers;


namespace Komodo.Managers
{
    class EntityManager:IEntityManager
    {
        //IServiceProvider mServices;
        //SpriteBatch sBatch;
        //ISceneManager mSceneManager;
        private List<X2DToken>mEntityList = null;

        //WIP entity dictionary for keeping a record of an entity with a related, unique ID
        private Dictionary<X2DToken, string> mEntityDictionary;

        IEntityFactory mFactory;
        X2DToken temp;
        //ICollisionManager mCManager;


        public EntityManager()
        { //Manager constructor
            //IServiceProvider xServices, SpriteBatch spriteBatch, ISceneManager sManager, IAIComponentManager aiManager, ICollisionManager cManager
        }

        public void ManagerSetup(IServiceProvider xServices, SpriteBatch pBatch, IAIComponentManager aiManager)
        { 
            //mServices = xServices;
            //sBatch = spriteBatch;
            //sceneManager = Kernel.Instance().mSceneManager;
            mEntityList = new List<X2DToken>();
            mFactory = new EntityFactory(xServices, pBatch, aiManager);
            //mAIComponentManager = aiManager;
            //mCManager = cManager;
        }

        //Create newly requested entities
        public List<X2DToken> AddNewEntities(List<Tuple<EntityType, Vector2>> pEntitiesData)
        {   
            //return a list of newly created entities
            List<X2DToken> NewEntityList = new List<X2DToken>();

            //will need some way of passing multiple entities to be created
            //return the new entities
            foreach(Tuple<EntityType,Vector2> EntityData in pEntitiesData)
            {
                NewEntityList.Add(CreateEntity(EntityData));
            }

            return NewEntityList;
        }



        private X2DToken CreateEntity(Tuple<EntityType,Vector2> pTuple)

        {   
           
           //FOR TEST - CREATE (multiple) X2DTOKENS AND THEIR PROPERTIES MANUALLY

           //UNTIL SCENE MANAGER SPECIFIES VECTORS, USE THESE VARIABLES:
            Vector2 pos = new Vector2(400, 200);

            mFactory.CreateEntity(pTuple.Item1, pTuple.Item2);
            temp = mFactory.TempEntity;
            mEntityList.Add(temp);
      
/*
          pos = new Vector2(200,000);
            mFactory.CreateEntity(EntityType.Enemy2, pos);
            temp = mFactory.TempEntity;
            mEntityList.Add(temp);
         

          pos = new Vector2(200, 390);
          mFactory.CreateEntity(EntityType.Enemy1, pos);
          temp = mFactory.TempEntity;
          mEntityList.Add(temp);
          

            pos = new Vector2(200, 300);
            mFactory.CreateEntity(EntityType.Metabolico, pos, sBatch, mServices, mAIComponentManager);
            temp = mFactory.TempEntity;
            mEntityList.Add(temp);*/

           /*1. Create a visual asset for the enitity - it's clothes if you will
           Asset = new VisualAsset(mServices);
           //2. Create the entity and pass it the visual asset - it decides WHAT to wear - until the factory does
           mEntityList.Add(new PlayerToken());
       
           Asset = new VisualAsset(mServices);
           mEntityList.Add(new MetabolicoToken(Asset, sBatch));
           */

          return temp;
        }

       public void RemoveEntities(List<X2DToken> rList)
       {
           

       }

       public void updateList()
       {
           //mEntityList = sceneManager.updateList(mEntityList);
          // mCManager.EntityList(mEntityList);
       }






       /*public void drawEntity()
       {
           //foreach (X2DToken T in mEntityList)
           {
               T.DrawSelf();
           }
          /* sBatch.Begin();
           Vector2 pos = new Vector2(0, -100);
           sBatch.Draw(mEntityList.All<X2DToken>, pos, Color.White);
           sBatch.End();*/




       }





      }
    

