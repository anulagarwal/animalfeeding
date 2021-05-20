using System;
using D2D.Core;
using UnityEngine;

namespace D2D.Gameplay
{
    public class PlayerMovement : GameStateMachineUser
    {
        [SerializeField] private float _speed;
        
        [HideInInspector] public float speedFactor = 1;

        private float Speed => _speed * speedFactor;

        protected override void OnGameFinish()
        {
            speedFactor = 0;
            enabled = false;
        }
    }
}