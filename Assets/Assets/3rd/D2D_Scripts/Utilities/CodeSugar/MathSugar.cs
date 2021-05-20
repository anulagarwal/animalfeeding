using System;
using UnityEngine;

namespace D2D.Utilities.CodeSugar
{
    public static class MathSugar
    {
        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }
        
        public static float SignedClamp(this float value, float range)
        {
            return Mathf.Clamp(value, -range, range);
        }
        
        public static float LimitMax(this float value, float max)
        {
            return Mathf.Min(value, max);
        }
        
        public static float LimitMin(this float value, float min)
        {
            return Mathf.Max(value, min);
        }
        
        public static float Abs(this float value)
        {
            return Mathf.Abs(value);
        }
        
        public static Vector3 SetY(this Vector3 target, float value)
        {
            target.y = value;
            return target;
        }

        public static float DistanceTo(this Vector3 from, Vector3 to)
        {
            return (from - to).magnitude;
        }
        
        public static float DistanceTo(this Transform from, Transform to)
        {
            return (from.position - to.position).magnitude;
        }
        
        // public static Transform ClosestTo(this Transform from, Transform[] to)
        // {
        //     return (from.position - to.position).sqrMagnitude;
        // }
    }
}