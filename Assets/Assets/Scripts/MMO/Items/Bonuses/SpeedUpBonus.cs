using UnityEngine;

namespace D2D
{
    public class SpeedUpBonus : ActionItem
    {
        [SerializeField] private float _speedIncreaseFactor;
        
        protected override void OnAction()
        {
            // Owner.GetComponent<UnitMovement>().speedFactor *= _speedIncreaseFactor;
        }
    }
}