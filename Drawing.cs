#region using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace OrProject
{
    
    class Drawing:FocusObject
    {
        #region Data
        protected Texture2D tex;
        protected Rectangle? sourceRec;
        protected Vector2 origin;
        public float rotation { get; set; }
        public Vector2 position { get; set; }
        protected Color color;
        public Vector2 scale;
        SpriteEffects effect;
        float layerDepth;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for a drawing
        /// </summary>
        /// <param name="tex">the texture of the drawing</param>
        /// <param name="position">the position of the drawing compared to 0,0</param>
        /// <param name="color">Used to change the color of the drawing, Color.White for no change</param>
        /// <param name="rotation">Used to rotate the drawing</param>
        /// <param name="scale">used to change the size of the drawing</param>
        /// <param name="layerDepth">Used to determine which drawing would be on top, 1 is to be on top</param>
        public Drawing (Texture2D tex, Vector2 position, Color color, float rotation, 
            Vector2 scale, float layerDepth = 0) //constructor for a drawing
        {
            this.tex = tex;
            this.position = position;
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
            Game1.EVENT_DRAW += this.Draw;

        }
        /// <summary>
        /// Constructor for the map
        /// </summary>
        /// <param name="tex">the texture of the map</param>
        /// <param name="scale">used to change the size of the drawing</param>
        public Drawing(Texture2D tex, Vector2 scale)
        {
            this.tex = tex;
            this.scale = scale;
            this.position = Vector2.Zero;
            this.sourceRec = null;
            this.color = Color.White;
            this.rotation = 0;
            this.origin = Vector2.Zero;
            this.effect = SpriteEffects.None;
            this.layerDepth = 0;
            Game1.EVENT_DRAW += this.Draw;
        }
        #endregion

        #region Draw
        public void Draw() //a fucntion used for drawing on the screen
        {
            Stat.sb.Draw(tex, position, sourceRec, color, rotation, origin, scale, effect, layerDepth);
        }
        #endregion

        #region makeTransparentColor
        /// <summary>
        /// a function used to change a specific color in a texture to be transparent
        /// </summary>
        /// <param name="color">The color to make transparent</param>
        public void makeTransparentColor(Color color) 

        {
            Color[] colors = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(colors);
            for(int i = 0; i < colors.Length; i++)  if (colors[i] == color) colors[i] = Color.Transparent;
            tex.SetData<Color>(colors);
        }
        #endregion
    }
}
