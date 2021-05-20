using System;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace D2D.Core
{
    /// <summary>
    /// Responsible for scene loading, takes data from ScenesSettings.
    /// </summary>
    public class SceneLoader : MonoBehaviour, ILazy
    {
        // The nam of current scene.
        public static string CurrentSceneName => SceneManager.GetActiveScene().name;
        
        /// <summary>
        /// Count of levels in game.
        /// </summary>
        public static int CountOfLevelsInGame => SceneManager.sceneCountInBuildSettings - 1;
        
        public event Action SceneReloading;
        
        /// <summary>
        /// Used for postponed scene loading. The scene with this name will be loaded 
        /// </summary>
        private string _nextSceneName;

        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = this.FindLazy<GameStateMachine>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                ReloadCurrentScene();
        }

        public void ReloadCurrentScene(float delay = 0)
        {
            DOVirtual.DelayedCall(delay, () => StartSceneLoading(CurrentSceneName));
        }

        public void LoadMainMenu()
        {
            StartSceneLoading(ScenesSettings.Instance.mainMenuSceneName);
        }

        public void LoadLevel(int levelNumber)
        {
            if (levelNumber < 1)
            {
                Debug.LogError("You tried to load level with number less than 1! I wll load level 1");
                levelNumber = 1;
            }

            if (levelNumber > CountOfLevelsInGame)
            {
                Debug.LogError("You tried to load level more than count of levels in game! I will load 1 level");
                levelNumber = 1;
            }

            StartSceneLoading(ScenesSettings.Instance.levelScenePrefix + levelNumber);
        }

        private void StartSceneLoading(string desiredSceneName)
        {
            _nextSceneName = desiredSceneName;
            
            _gameStateMachine.Push(new PostgameState());

            // Load scene immediately or do it after scene transition finish
            var sceneTransition = FindObjectOfType<SceneTransition>();
            if (sceneTransition == null)
            {
                FinishSceneLoading();
            }
            else
            {
                sceneTransition.Completed += FinishSceneLoading;
            }
        }

        private void FinishSceneLoading()
        {
            var sceneTransition = FindObjectOfType<SceneTransition>();
            
            if (sceneTransition != null)
                sceneTransition.Completed -= FinishSceneLoading;

            if (_nextSceneName == CurrentSceneName)
                SceneReloading?.Invoke();
                
            DOTween.Clear(true);
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
