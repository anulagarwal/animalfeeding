using System;
using System.Collections;
using System.Collections.Generic;
using D2D.Common;
using D2D.Core;
using D2D.Databases;
using D2D.Utilities;
using DG.Tweening;
using UnityEngine;

public class Block : GameStateMachineUser
{
    [SerializeField] private float _gain;
    
    public TrackableValue<int> Counter { get; } = new TrackableValue<int>();

    private void Start()
    {
        StateMachine.Push(new RunningState());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Counter.Value++;

            this.FindLazy<PlayerDatabase>().MoneyContainer.Value += _gain;
        }
    }
}
