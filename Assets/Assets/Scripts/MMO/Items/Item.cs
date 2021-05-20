using System;
using D2D.Gameplay;
using UnityEngine;

namespace D2D
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;

        public string Name => _name;

        public Sprite Icon => _icon;

        public GameObject Prefab => _prefab;

        public bool IsPicked { get; private set; }
        
        protected GameObject Owner { get; private set; }

        public void Pick(GameObject owner)
        {
            if (IsPicked)
                throw new Exception("Already picked!");

            IsPicked = true;
            Owner = owner;

            OnPick(owner);
        }

        public void Throw()
        {
            if (!IsPicked)
                throw new Exception("You can not throw item which not picked!");

            IsPicked = false;
            Owner = null;
            
            OnThrow();
        }

        protected virtual void OnPick(GameObject owner) { }

        protected virtual void OnThrow() { }
    }
}