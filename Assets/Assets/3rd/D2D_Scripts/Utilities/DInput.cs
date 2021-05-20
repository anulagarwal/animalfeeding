using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace D2D.Utilities
{
    public class DInput
    {
        private const int MouseLeftButtonID = 0;

        public static bool isInputOn = true;
        
        public static bool IsMousePressing => isInputOn && Input.GetMouseButton(MouseLeftButtonID);
        
        public static bool IsMousePressed => isInputOn && Input.GetMouseButtonDown(MouseLeftButtonID);
        
        public static bool IsMouseReleased => isInputOn && Input.GetMouseButtonUp(MouseLeftButtonID);

        public static bool IsMouseOverGameObject
        {
            get
            {
                var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
                {
                    position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
                };
                var results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
                return results.Count > 0;
            }
        }
    }
}