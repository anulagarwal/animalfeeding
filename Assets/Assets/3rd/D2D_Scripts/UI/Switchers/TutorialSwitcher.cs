using D2D.Core;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.UI
{
    public class TutorialSwitcher : GameStateMachineUser
    {
        [SerializeField] private GameObject _tutorial;

        private void OnEnable()
        {
            if (UISettings.Instance.isTutorialVisible)
            {
                _tutorial.On(canBeNull: false);
            }
        }
    }
}
