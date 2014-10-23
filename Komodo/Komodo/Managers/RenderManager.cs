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
    class RenderManager:IRenderer
    {
        ISceneManager mSceneMan;
        SpriteBatch mSpriteBatch;
        List<X2DToken> mEntityRenderList;
        IServiceProvider mService;
        public Texture2D background;
        ContentManager Content;


        public void ManagerSetup(ISceneManager pSceneMan, SpriteBatch pBatch, IServiceProvider service)
        {
            mSceneMan = pSceneMan;
            mSpriteBatch = pBatch;
            Content = new ContentManager(service, "content");
            background = Content.Load<Texture2D>("background");
        }

      

        public void Draw(ref GameTime gameTime)
        {
            mSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            mEntityRenderList = mSceneMan.EntitiesToDraw();

            //Little bit of code to stop the token list being drawn if it does not contain any tokens
            //if (mSceneMan.EntitiesToDraw() != null)
            //{
//  
                foreach (X2DToken T in mEntityRenderList)
                {
                    
                    T.DrawSelf(mSpriteBatch);
                }
            //}
//                
            mEntityRenderList = null;
                //mSpriteBatch.End();
        }
    }
}
