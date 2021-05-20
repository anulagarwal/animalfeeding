using D2D.Utilities;
using UnityEngine;
using D2D.Utils;

namespace D2D.Core
{
    /// <summary>
    /// Contains all system game data.
    /// A bit a lot of responsibilities you might say, but creating data class
    /// for every single system it is not so handful too
    /// </summary>
    [CreateAssetMenu(fileName = "ScenesSettings", menuName = "SO/ScenesSettings")]
    public class ScenesSettings : SingletonData<ScenesSettings>
    {
        public string mainMenuSceneName = "MainMenu";
        public string levelScenePrefix = "Level_";

        [Space(10)] 
        
        public bool scenesLooped = true;
        public bool lazyRuntimeCreationEnabled;
    }
}