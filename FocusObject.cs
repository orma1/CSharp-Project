#region using
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace OrProject
{
    #region FocusObject
    interface FocusObject //An interface made for being able to focus the camera on an object of any type
        {
            Vector2 position { get; }
            float rotation { get; }
        }
    #endregion
}
