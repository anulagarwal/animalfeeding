using D2D.Common;
using D2D.Databases;
using D2D.Utilities;
using UnityEngine;

namespace D2D.UI
{
    public class MoneyLabel : TrackableValueLabel<float>
    {
        [SerializeField] private bool _useDollarPostfix = true;

        public override TrackableValue<float> Trackable => 
            this.FindLazy<PlayerDatabase>().MoneyContainer;

        protected override string ValueToText(float value)
        {
            return value.Round() + (_useDollarPostfix ? "$" : "");
        }
    }
}