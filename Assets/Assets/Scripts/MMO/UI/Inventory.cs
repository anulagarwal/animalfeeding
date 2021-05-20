using UnityEngine;

namespace D2D
{
    /// <summary>
    /// In future there will be also cells, to renderer actual items of the inventory.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ItemBag _itemBag;

        // By click or numbers on keyboard we can change it...
        public Item SelectedItem { get; private set; }

        private void OnEnable()
        {
            _itemBag.ItemsChanged += Redraw;
        }

        private void OnDisable()
        {
            _itemBag.ItemsChanged -= Redraw;
        }

        private void Redraw()
        {
            if (!_itemBag.Items.Contains(SelectedItem))
                SelectedItem = _itemBag.Items[0];
        }
    }
}