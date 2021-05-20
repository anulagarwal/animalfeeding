using D2D.Gameplay;
using UnityEngine;

namespace D2D
{
    public class CureBonus : ActionItem
    {
        [SerializeField] private float _healPoints;
        
        protected override void OnAction()
        {
            Owner.GetComponent<Health>().Heal(_healPoints);
        }
    }
}