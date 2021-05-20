using UnityEngine;

namespace D2D
{
    [CreateAssetMenu(fileName = "SimpleUpgradeChain", menuName = "SO/SimpleUpgradeChain", order = 0)]
    public class SimpleUpgradeChain : UpgradeChain
    {
        [Space(10)]
        
        [SerializeField] private float _startingCost;
        [SerializeField] private float _costPerLevel;
        
        public override float CalculateCost(int level)
        {
            return _startingCost + _costPerLevel * level;
        }
    }
}