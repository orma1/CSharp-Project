#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace OrProject
{
    class Engine
    {
        #region data
        public float MaximumSpeed { get; set; }
        public float Speed { get; set; }
        public float AccelerationSpeed { get; set; }
        #endregion

        /// <summary>
        /// A constructor used to make an engine for the vehicle
        /// </summary>
        /// <param name="MaximumSpeed">Represents the maximum speed possible for the vehicle to reach</param>
        /// <param name="AccelerationSpeed">Represents the rate the vehicle can accelerate</param>

        #region Constructor
        public Engine(float MaximumSpeed, float AccelerationSpeed)
        {
            this.MaximumSpeed = MaximumSpeed;
            Speed = 0;
            this.AccelerationSpeed = AccelerationSpeed;
        }
        #endregion

        #region Accelerate
        /// <summary>
        /// a function used to determine if the car is accelerating 
        /// </summary>
        /// <param name="forward">used to determine if the vehicle is moving forward or backwards</param>
        public void Accelerate(Boolean forward) 
        {
            if (forward)
            {
                Speed += AccelerationSpeed;
                if (Speed > MaximumSpeed) Speed = MaximumSpeed;
            }
            else
            {
                Speed -= AccelerationSpeed;
                if (Speed < -MaximumSpeed) Speed = -MaximumSpeed;
            }
        }
        #endregion
    }
}
