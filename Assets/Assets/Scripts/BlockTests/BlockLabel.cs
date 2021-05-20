using System;
using D2D.Common;
using UnityEngine;

namespace D2D
{
    public class BlockLabel : TrackableValueLabel<int>
    {
        [SerializeField] private Block _block;

        public override TrackableValue<int> Trackable => _block.Counter;
    }
}