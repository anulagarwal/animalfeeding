using System;
using System.Collections.Generic;
using D2D.Gameplay;
using UnityEngine;

namespace D2D
{
    /// <summary>
    /// Every Unit can have such a bag.
    /// </summary>
    public class ItemBag : MonoBehaviour
    {
        public List<Item> Items => _items.GetRange(0, _items.Count);
        
        public event Action ItemsChanged;
        
        private readonly List<Item> _items = new List<Item>();
        
        private CollectablesPicker _picker;

        private void OnEnable()
        {
            _picker = GetComponent<CollectablesPicker>();
            _picker.Picked += AddIfItem;
        }

        private void OnDisable()
        {
            _picker.Picked -= AddIfItem;
        }

        /// <summary>
        /// Picker can detect not a item but the collectable, such a coin.
        /// We won`t to add something like what, we add to the inventory only items. 
        /// </summary>
        private void AddIfItem(GameObject obj)
        {
            var newItem = obj.GetComponent<Item>();
            if (newItem != null)
            {
                AddItem(newItem);
            }
        }

        /// <summary>
        /// Listen for a picker (Picked event).
        /// But in this case wrapper method call this method.
        /// </summary>
        public void AddItem(Item newItem)
        {
            if (newItem == null)
                throw new NullReferenceException("Item to add");

            if (newItem.IsPicked)
                throw new Exception("Item already picked! But you want to add it to the bag.");
            
            _items.Add(newItem);
            ItemsChanged?.Invoke();
        }

        /// <summary>
        /// We can listen for to UI button click here, for instance
        /// </summary>
        public void RemoveItem(Item removingItem)
        {
            if (removingItem == null)
                throw new NullReferenceException("Item to remove");
            
            if (!removingItem.IsPicked)
                throw new Exception("Item is not picked! But you want to remove it from the bag.");
            
            _items.Remove(removingItem);
            ItemsChanged?.Invoke();
        }
    }
}