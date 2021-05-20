using System;
using UnityEngine;
using D2D.Core;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine.SceneManagement;

namespace D2D.Gameplay
{
    /// <summary>
    /// Contains default level functionality.
    /// Here can be goal and track of this goal
    /// </summary>
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _levelNumber = -1;

        public int LevelNumber
        {
            get
            {
                if (_levelNumber < 1)
                {
                    DLog.PrintRed("Level number of this level is less than 1! I Will return 1");
                    return 1;
                }

                if (_levelNumber > SceneLoader.CountOfLevelsInGame)
                {
                    DLog.PrintRed("Level number if this level is more than levels count! I will return number of last level");
                    return SceneLoader.CountOfLevelsInGame;
                }

                return _levelNumber;
            }
        }

        public bool IsLast => _levelNumber == SceneLoader.CountOfLevelsInGame;

        private void OnValidate()
        {
            string levelPrefix = ScenesSettings.Instance.levelScenePrefix;
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (!currentSceneName.Contains(levelPrefix) || _levelNumber > -1)
                return;
            
            if (!int.TryParse(currentSceneName.Replace(levelPrefix, ""), out int parsedLevelNumber))
            {
                _levelNumber = 1;
                DLog.PrintRed($"Can`t parse level number from scene name: {currentSceneName}. I will set it to 1");
            }
            
            _levelNumber = parsedLevelNumber;
        }
    }
}