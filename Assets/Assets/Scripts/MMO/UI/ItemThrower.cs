using System;
using D2D.UI;
using UnityEngine;

namespace D2D
{
    /// <summary>
    /// In future we can expand this class to throw item also by drag and drop.
    /// </summary>
    public class ItemThrower : MonoBehaviour
    {
        [SerializeField] private ItemBag _bag;
        [SerializeField] private Inventory _inventory;

        [Space(10)] 
        
        [SerializeField] private DButton _throwButton;

        private void OnEnable()
        {
            _throwButton.Clicked += ThrowSelectedItem;
        }

        private void OnDisable()
        {
            _throwButton.Clicked -= ThrowSelectedItem;
        }

        private void ThrowSelectedItem()
        {
            _bag.RemoveItem(_inventory.SelectedItem);
        }
    }
}