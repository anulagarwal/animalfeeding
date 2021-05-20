using System;
using DG.Tweening;
using UnityEngine;

namespace D2D.Utilities
{
    public static class ActivationSugar
    {
        public static void On(this GameObject target, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;

            target.SetActive(true);
        }
        
        public static void On(this GameObject target, float after, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;

            DOVirtual.DelayedCall(after, () => On(target, canBeNull));
        }
        
        public static void Off(this GameObject target, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;
            
            target.SetActive(false);
        }

        public static void Off(this GameObject target, float after, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;

            DOVirtual.DelayedCall(after, () => Off(target, canBeNull));
        }
        
        public static void Reactivate(this GameObject target, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;
            
            target.SetActive(false);
            target.SetActive(true);
        }
        
        public static void Reactivate(this GameObject target, float delay, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;
            
            target.SetActive(false);
            DOVirtual.DelayedCall(delay, () => target.SetActive(true));
        }

        public static void SwitchActivity(this GameObject target, bool canBeNull = true)
        {
            if (!IsObjectValid(target, canBeNull))
                return;
            
            target.SetActive(!target.activeSelf);
        }

        private static bool IsObjectValid(GameObject target, bool canBeNull)
        {
            if (target == null)
            {
                if (canBeNull)
                    return false;
                
                throw new ArgumentNullException("GameObject you want to change activity");
            }

            return true;
        }
    }
}