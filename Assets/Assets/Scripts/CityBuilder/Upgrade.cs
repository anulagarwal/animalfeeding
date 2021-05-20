using System;
using UnityEngine;

namespace D2D
{
    [CreateAssetMenu(fileName = "Building", menuName = "SO/Building", order = 0)]
    public class Upgrade : ScriptableObject
    {
        public new string name;
        public Sprite icon;
        public GameObject prefab;

        [Space(10)] 
        
        public int level;
        public float cost;

        private void OnValidate()
        {
            cost = Math.Min(cost, 0);
            level = Math.Min(level, 1);
        }
    }
}