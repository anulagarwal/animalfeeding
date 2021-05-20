using D2D.Core;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class JoystickSwitcher : GameStateMachineUser
    {
        [SerializeField] private GameObject _joystickBody;

        protected override void OnGameFinish()
        {
            _joystickBody.Off();
        }
    }
}