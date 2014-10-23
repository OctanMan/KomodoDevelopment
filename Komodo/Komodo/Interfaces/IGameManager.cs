using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komodo.Interfaces
{
    interface IGameManager
    {
         //DifficultyScale;
        //shows the Difficulty level of the current level and manipulate the objects based on each difficulty.
   
         void ReadGameContent();
        
            //this method needs to read content to a file so that the content can be loaded into the game.
        

        void ProcessEntities();
        
            //processes the entities requests to add into the game such as spawning fireballs.
        


        

         


    }
}
