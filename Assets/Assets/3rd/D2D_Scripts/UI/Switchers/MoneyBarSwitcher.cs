using D2D.Core;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.UI
{
    public class MoneyBarSwitcher : GameStateMachineUser
    {
        [SerializeField] private GameObject _moneyBar;

        private void OnEnable()
        {
            Hide();

            if (UISettings.Instance.isMoneyBarVisible)
            {
                StateMachine.On<RunningState>(Show);
            }
        }

        public void Show()
        {
            _moneyBar.On(canBeNull: false);
        }

        public void Hide()
        {
            _moneyBar.Off(canBeNull: false);
        }
    }
}
