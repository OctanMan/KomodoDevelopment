using System;
using Microsoft.Xna.Framework;

namespace Komodo
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            
            {
                Kernel k1 = Kernel.Instance();
                Kernel k2 = Kernel.Instance();
                

                //An instance of Kernal will only run 1 Kernal no other instance of Kernal can be run.
                //This shows the use of the Singleton instance as the colour of the k1 background screen
                //is changed by editing the colour in the k2 as they are the same instance. :)
                //k2.SingletonCol = Color.Red;
                k1.Run();
                
            }
        }
    }
#endif
}

