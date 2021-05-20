using UnityEngine;

namespace D2D.Utilities
{
    public static class GameplaySugar
    {
        public static bool Is<T>(this Collision other) where T:Component
        {
            return other.gameObject.TryGetComponent(out T t);
        }
        
        public static bool Is<T>(this Collider other) where T:Component
        {
            return other.gameObject.TryGetComponent(out T t);
        }
        
        public static bool Is<T>(this GameObject other) where T:Component
        {
            return other.TryGetComponent(out T t);
        }
    }
}