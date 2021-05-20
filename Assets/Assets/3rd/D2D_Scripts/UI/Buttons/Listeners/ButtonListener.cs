using UnityEngine;

namespace D2D.UI
{
    [RequireComponent(typeof(DButton))]
    public abstract class ButtonListener : MonoBehaviour
    {
        protected DButton Button { get; private set; }

        private void OnEnable()
        {
            Button = GetComponent<DButton>();
            Button.Clicked += OnClick;
        }

        private void OnDisable()
        {
            Button.Clicked -= OnClick;
        }

        protected abstract void OnClick();
    }
}