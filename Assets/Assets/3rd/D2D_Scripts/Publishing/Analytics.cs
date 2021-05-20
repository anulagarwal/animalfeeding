using System;
using D2D.Core;
using D2D.Gameplay;
using D2D.Utilities;
using UnityEngine;

namespace D2D
{
    public class Analytics : GameStateMachineUser
    {
        private int LevelNumber => FindObjectOfType<Level>().LevelNumber;

        private SceneLoader _sceneLoader;

        private void OnEnable()
        {
            _sceneLoader = this.FindLazy<SceneLoader>();
            _sceneLoader.SceneReloading += OnGameReload;
        }

        private void OnDisable()
        {
            _sceneLoader.SceneReloading -= OnGameReload;
        }

        private void Start()
        {
            // The player starts the game
            
            // GameAnalytics.Initialize();
        }

        private void OnGameReload()
        {
            // The player reloads the game
        }

        protected override void OnGameWin()
        {
            // The player wins
        }

        protected override void OnGameLose()
        {
            // The player loses
        }
    }
}