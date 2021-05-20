using D2D.Animations;
using D2D.Databases;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Gameplay
{
    public class Coin : Collectable
    {
        [SerializeField] private int _cost = 1;
        [SerializeField] private GameObject _pickEffect;

        private DataContainer<float> _moneyContainer;

        private void Awake()
        {
            _moneyContainer = this.FindLazy<PlayerDatabase>().MoneyContainer;
        }

        protected override void OnPick(GameObject owner)
        {
            // Add money bonus
            _moneyContainer.Value += _cost;
            
            // Some sparks, etc
            _pickEffect.On();
        }
    }
}