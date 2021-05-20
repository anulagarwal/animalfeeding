using System;
using UnityEngine;

namespace D2D
{
    [Serializable]
    public class UpgradeChainEntity
    {
        public string name;
        public Sprite icon;
        public GameObject prefab;
    }
    
    [CreateAssetMenu(fileName = "UpgradeChain", menuName = "SO/UpgradeChain", order = 0)]
    public abstract class UpgradeChain : ScriptableObject
    {
        [SerializeField] private UpgradeChainEntity[] _upgrades;
        
        public Upgrade this[int level]
        {
            get
            {
                if (level <= 0)
                    throw new Exception("Level must be 1 or more!");

                UpgradeChainEntity entity;
                entity = level > _upgrades.Length ? _upgrades[_upgrades.Length - 1] :
                    _upgrades[level - 1];
                
                return new Upgrade
                {
                    name = entity.name,
                    icon = entity.icon,
                    prefab = entity.prefab,
                    level = level,
                    cost = CalculateCost(level)
                };
            }
        }
        
        public abstract float CalculateCost(int level);
    }
}