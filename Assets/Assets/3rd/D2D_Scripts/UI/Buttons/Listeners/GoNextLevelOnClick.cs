using D2D.Core;
using D2D.Gameplay;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.UI
{
    public class GoNextLevelOnClick : ButtonListener
    {
        private Level _level;
        
        private void Start()
        {
            _level = FindObjectOfType<Level>();
            if (_level == null)
                gameObject.SetActive(false);
            
            if (!ScenesSettings.Instance.scenesLooped && _level.IsLast)
                gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnClick();
            }
        }

        protected override void OnClick()
        {
            var loader = this.
                FindLazy<SceneLoader>();
            
            int nextLevel = _level.LevelNumber + 1;
            if (ScenesSettings.Instance.scenesLooped && _level.IsLast)
                nextLevel = DMath.Random(1, 2);
            
            loader.LoadLevel(nextLevel);
        }
    }
}