using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Interfaces;
using Komodo.Managers;

namespace Komodo.Interfaces
{
    interface IScene
    {
             List<Tuple<EntityType, Vector2>> SceneEntities { get; }
    }
}
