using D2D.Gameplay;
using UnityEngine;

namespace D2D.Utilities
{
    /// <summary>
    /// For time management in game and especially for slow-mos.
    /// </summary>
    public static class DTime
    {
        private const float FixedDeltaTimeFactor = .02f;
        
        public static float TimeScale
        {
            get => Time.timeScale;
            set
            {
                Time.timeScale = value;
                Time.fixedDeltaTime = value * FixedDeltaTimeFactor;
            }
        }
    }
}