using D2D.Core;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using UnityEngine;

namespace D2D.UI
{
    public class LevelResultWindowSwitcher : GameStateMachineUser
    {
        [SerializeField] private GameObject _winWindow;
        [SerializeField] private GameObject _loseWindow;

        private void OnEnable()
        {
            _winWindow.Off();
            _loseWindow.Off();

            StateMachine.On<WinState>(ShowWinWindowAfterDelay);
            StateMachine.On<LoseState>(ShowLoseWindowAfterDelay);
        }
        
        private void ShowWinWindowAfterDelay()
        {
            float delay = UISettings.Instance.winWindowOpenDelay;
            _winWindow.On(after: delay);
        }
        private void ShowLoseWindowAfterDelay()
        {
            float delay = UISettings.Instance.loseWindowOpenDelay;
            _loseWindow.On(after: delay);
        }
    }
}