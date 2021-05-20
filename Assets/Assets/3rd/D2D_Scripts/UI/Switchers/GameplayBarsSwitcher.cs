using D2D.Core;
using D2D.Utilities;
using UnityEngine;

namespace D2D.UI
{
    public class GameplayBarsSwitcher : GameStateMachineUser
    {
        [SerializeField] private GameObject[] _bars;

        private void Start()
        {
            _bars.ForEach(b => b.Off());
        }

        protected override void OnGameRun()
        {
            _bars.ForEach(b => b.On());
        }

        protected override void OnGameFinish()
        {
            _bars.ForEach(b => b.Off());
        }
    }
}