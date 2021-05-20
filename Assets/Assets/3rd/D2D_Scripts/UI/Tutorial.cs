using D2D.Core;
using D2D.UI;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class Tutorial : GameStateMachineUser
    {
        private void Update()
        {
            if (Input.anyKey || DInput.IsMousePressing)
            {
                Confirm();
            }
        }

        private void Confirm()
        {
            StateMachine.Push(new RunningState());
            Destroy(gameObject);
        }
    }
}