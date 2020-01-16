#region using
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace OrProject
{
    #region BasicKeys
    abstract class BasicKeys
    {
        public abstract bool Up();
        public abstract bool Down();
        public abstract bool Right();
        public abstract bool Left();
    }
    #endregion

    #region PlayerKeys
    class PlayerKeys : BasicKeys
    {
        private Keys up, down, right, left;
        #endregion

        #region Constructor
        /// <summary>
        /// A constructor used to determine the keys used
        /// </summary>
        /// <param name="up">Represents the up key, for the vehicle it is used to move it forward</param>
        /// <param name="down">Represents the down key, for the vehicle it is used to move it backwards</param>
        /// <param name="right">Represents the right key, for the vehicle it is used to rotate to the right</param>
        /// <param name="left">Represents the left key, for the vehicle it is used to rotate to the left</param>
        public PlayerKeys(Keys up, Keys down, Keys right, Keys left)
        {
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
        }
        #endregion

        #region up
        public override bool Up()
        {
            return Keyboard.GetState().IsKeyDown(up);
        }
        #endregion

        #region Down
        public override bool Down()
        {
            return Keyboard.GetState().IsKeyDown(down);
        }
        #endregion

        #region right
        public override bool Right()
        {
            return Keyboard.GetState().IsKeyDown(right);
        }
        #endregion

        #region left
        public override bool Left()
        {
            return Keyboard.GetState().IsKeyDown(left);
        }
        #endregion
    }
}
