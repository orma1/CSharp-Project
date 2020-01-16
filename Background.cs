#region using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace OrProject
{
    class Background: Drawing
    {
        #region data
        public enum BackgroundType 
            //the types of ground in the background
        {
            Road,
            Grass,
            Edge
        }
        private BackgroundType[,] background;
        public BackgroundType this[float x, float y]
        {
            get
            {
                x /= scale.X;
                y /= scale.Y;
                if(x<0 || x> background.GetLength(0) || y<0 || y>= background.GetLength(1))
                {
                    return BackgroundType.Edge;
                }
                return background[(int)x, (int)y];
            }
        }
        #endregion

        /// <summary>
        /// A constructor for making a background
        /// </summary>
        /// <param name="tex">The texture of the background</param>
        #region Constructor
        public Background(Texture2D tex)
            :base(tex, Vector2.One)
        {
            background = new BackgroundType[tex.Width, tex.Height];
            Color[] Colors = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(Colors);
            for (int w = 0;  w < tex.Width;  w++)
                /*this function puts the default background type as edge, if the pixel is black it sets it to road
                and if green to grass*/
            {
                for (int h = 0; h < tex.Height; h++)
                {
                    background[w, h] = BackgroundType.Edge;
                    if(Colors[w + h * tex.Width] == Color.Black)
                    {
                        background[w, h] = BackgroundType.Road;
                    }
                    if(Colors[w + h * tex.Width] == Color.Green)
                    {
                        background[w, h] = BackgroundType.Grass;
                    }
                }

            }
        }
        #endregion
    }
}
