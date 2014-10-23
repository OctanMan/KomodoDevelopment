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
    class SceneGraph:ISceneGraph
    {
        List<X2DToken> AllOfGraph;
        List<X2DToken> drawList;


        //Consructor - initialise blank Graph Lists 
        public SceneGraph()
        {
            AllOfGraph = new List<X2DToken>();
            drawList = new List<X2DToken>();
        }
        
        public void calculateView()
        {

        }


        //Graph Management Methods*****************************************************

        //Reurn the Complete Graph - usefull for checking all the scene graph contains
        public List<X2DToken> CompleteGraph
        {get {return AllOfGraph;}}

        //Append the passed list of X2DTokens to the SceneGraph
        public void AppendToGraph(List<X2DToken> pList)
        {
            AllOfGraph.AddRange(pList);
        }

        //Remove the requested X2DTokens from the SceneGraph 
        public void RemoveFromGraph(List<X2DToken> pList)
        {
            if (pList != null)
            {
                foreach (X2DToken T in pList)
                {
                    CompleteGraph.Remove(T);
                }
            }
        }


        //Returns a list of Tokens to draw based off of a calculation - the view area w/buffer
        public List<X2DToken> Draw()
        {
            calculateDraw();
            
            return drawList;
        }

        //Calculates what Tokens should and shouldn't be drawn
        private void calculateDraw()
        {
            drawList.Clear();
            foreach (X2DToken T in AllOfGraph)
            {
                if (T.worldPos.X > 0 && T.worldPos.X < 900)
                {
                    drawList.Add(T);
                }
                else
                {
                    //drawList = null;
                }
            }
        }

        }

    }

