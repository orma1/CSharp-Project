#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace OrProject
{
    class Camera
    {
        #region data
        public Matrix matri { get; private set; }
        public FocusObject focus { get; private set; }
        public Vector2 zooming { get; private set; }
        public Vector2 Position { get; private set; }
        Viewport vp;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for camera
        /// </summary>
        /// <param name="vp">used to gather information about the size of the window</param>
        /// <param name="focus">The object you want the camera to focus on</param>
        /// <param name="zooming">Used to zoom the camera in or out</param>
        public Camera(Viewport vp, FocusObject focus, Vector2 zooming)
        {
            this.focus = focus;
            this.zooming = zooming;
            this.vp = vp;
            Position = new Vector2(0,0);
        }
        #endregion

        #region UpdateMatri
        public void UpdateMatri()
            /* A function used to apply a Matrix that first moves the object to 0,0 then applies a rotation,
               then applies the scale, and then moves the camera so the object will be in the middle */
        {
            matri = Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                Matrix.CreateRotationZ(-focus.rotation * 0.1f) *
                Matrix.CreateScale(this.zooming.X, this.zooming.Y, 1f) *
                Matrix.CreateTranslation(vp.Width/2, vp.Height/2, 0);
            Position = Vector2.Lerp(focus.position, Position, 0.5f);
        }
        #endregion
    }
}
