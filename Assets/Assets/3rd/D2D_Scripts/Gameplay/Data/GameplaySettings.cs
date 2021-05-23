using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Gameplay
{
    /// <summary>
    /// Maybe it will be better to split to more specific settings.
    /// But if it is a small game prototype maybe it is more convenient to keep it all there. 
    /// </summary>
    [CreateAssetMenu(fileName = "GameplaySettings", menuName = "SO/GameplaySettings")]
    public class GameplaySettings : SingletonData<GameplaySettings>
    {
        public Color normalDotColor;
        public Color filledDotColor;

        [Space] 
        
        public Vector2 patienceOnStart;
    }
}