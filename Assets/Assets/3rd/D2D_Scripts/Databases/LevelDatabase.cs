using System;
using D2D.Core;
using D2D.Gameplay;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Databases
{
    public class LevelCompletionContainer
    {
        private const string Key = "CompletedLevel_";
        private const int LevelCompletionFlag = 1;
    
        public bool Get(int levelNumber)
        {
            return ES3.Load(Key+levelNumber, 0) == LevelCompletionFlag;
        }
    
        public void Set(int levelNumber, bool state = true)
        {
            ES3.Save(Key+levelNumber, state ? LevelCompletionFlag : 0);
        }
    }
    
    public class LevelDatabase : GameStateMachineUser, ILazy
    {
        private LevelCompletionContainer _levelCompletionContainer = 
            new LevelCompletionContainer();

        /// <summary>
        /// Recent level which player played
        /// </summary>
        public int RecentLevel
        {
            get => PlayerPrefs.GetInt(nameof(RecentLevel), 1);
            set
            {
                if (value < 1)
                {
                    Debug.LogError("You try to save recent level less than 1. I will save 1");
                    value = 1;
                }

                if (value > SceneLoader.CountOfLevelsInGame)
                {
                    Debug.LogError("You try to save recent level higher that levels count. I will save last");
                    value = SceneLoader.CountOfLevelsInGame;
                }
                
                PlayerPrefs.GetInt(nameof(RecentLevel), value);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            
            SaveRecentLevel();
        }

        protected override void OnGameWin()
        {
            var level = FindObjectOfType<Level>();
            if (level == null)
                throw new Exception("Level db is exists but the level is not! Add a level.");
            
            _levelCompletionContainer.Set(level.LevelNumber);
            
            DLog.PrintBlue($"Level: {level.LevelNumber} completion saved.");
        }

        private void SaveRecentLevel()
        {
            var level = FindObjectOfType<Level>();
            if (level == null)
                return;

            RecentLevel = level.LevelNumber;

            DLog.PrintBlue($"Recent level: {level.LevelNumber} saved.");
        }
    }
}