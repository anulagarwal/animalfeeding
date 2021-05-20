using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Utilities
{
    public static class TransformSugar
    {
        public static List<Transform> GetChildTransforms(this Transform target)
        {
            var childList = new List<Transform>();
            foreach (Transform child in target)
            {
                childList.Add(child);
            }

            return childList;
        }
    }
}