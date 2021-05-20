using System;
using UnityEngine;

namespace D2D
{
    public class Weapon : Item
    {
        private void Update()
        {
            if (!IsPicked)
                return;
            
            // Shooting here ...
        }
    }
}