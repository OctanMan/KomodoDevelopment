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
    public class VisualAsset
    {
       public Texture2D mTexture;
        ContentManager content;
        
        public VisualAsset(IServiceProvider xService)
        {
            content = new ContentManager(xService, "Content");
        }

        public void loadAssets(string name)
        {
            mTexture = content.Load<Texture2D>(name);
            

        }

    }
}
