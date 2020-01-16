#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;
#endregion

namespace OrProject
{
    public delegate void DlgtUpdate(GameTime gameTime);
    public delegate void DlgtDraw();
    static class Stat
    {
        #region data
        public static ContentManager cm;
        public static SpriteBatch sb;
        public static Background background;
        #endregion

        #region Constructor
        /// <summary>
        /// a function used to bring the drawing capabilities from Game1 class to other classes
        /// </summary>
        /// <param name="cm">Used in order to be able to get data from the content folder</param>
        /// <param name="sb"></param>
        /// <param name="gd">The Graphics device is used in order to draw on screen</param>
        public static void Initialize(ContentManager cm, SpriteBatch sb, GraphicsDevice gd)
        {
            Stat.cm = cm;
            Stat.sb = sb;
        }
        #endregion
    }
}
