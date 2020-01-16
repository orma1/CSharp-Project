#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace OrProject
{
    
    class Vehicle:Drawing
    {
        #region data
        public float deltaRotation;
        public Vector2 Velocity { get; private set; }
        public Engine engine { get; set; }
        public BasicKeys basicKeys { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// A constructor used for creating a vehicle
        /// </summary>
        /// <param name="tex">The texture of the vehicle</param>
        /// <param name="position">The position you want to draw the vehicle in</param>
        /// <param name="Origin">The point on the texture to refer to</param>
        /// <param name="engine">The engine of the vehicle</param>
        /// <param name="events">Used to know if you want to include the vehicle in the update process in Game1 class.</param>
        public Vehicle(Texture2D tex, Vector2 position, Vector2 Origin, Engine engine, bool events)
            : base(tex, position, Color.White, 0.0f, new Vector2(1, 1), 0.0f)
        {
            this.engine = engine;
            this.Velocity = Velocity;
            if (events) Game1.EVENT_UPDATE += this.Update;
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime) //the update function for the vehicle
        {
            deltaRotation = 0;
            if(basicKeys.Right() && Math.Abs(engine.Speed) > 0.3f)
            {
                deltaRotation += 0.03f;
            }
            if (basicKeys.Left() && Math.Abs(engine.Speed) > 0.3f)
            {
                deltaRotation -= 0.03f;
            }
            rotation += deltaRotation;
            Vector2 direction = Vector2.Transform(Vector2.UnitX, Matrix.CreateRotationZ(rotation));
            Velocity = engine.Speed * direction;
            if (!(Stat.background[position.X + Velocity.X, position.Y + Velocity.Y] == Background.BackgroundType.Road))
            {
                Velocity *= -1f;
                engine.Speed = 0;
            }
            if (basicKeys.Up()) engine.Accelerate(true);
            if (basicKeys.Down()) engine.Accelerate(false);
            position += Velocity;
            
        }
        #endregion
    }
}
