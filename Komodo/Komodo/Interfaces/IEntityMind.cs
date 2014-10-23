using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komodo.Interfaces
{
    public interface IEntityMind
    {
        //Interface for AI Minds - possible to 'pop-in and pop-out' a mind from a reference of this
 
        void UpdateMind();
    }
}
