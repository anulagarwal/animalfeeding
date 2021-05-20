using D2D.Core;
using D2D.Utilities;
using UnityEngine;

namespace D2D.Cameras
{
    public class GameStateCameraShake : CameraShake
    {
        [SerializeField] private ShakeProfile _winShake;
        [SerializeField] private ShakeProfile _loseShake;
        
        private GameStateMachine _gameStateMachine;

        private void OnEnable()
        {
            _gameStateMachine = this.FindLazy<GameStateMachine>();

            _gameStateMachine.On<WinState>(() => Shake(_winShake));
            _gameStateMachine.On<LoseState>(() => Shake(_loseShake));
        }
    }
}