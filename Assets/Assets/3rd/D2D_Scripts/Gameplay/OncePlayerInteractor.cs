using System;
using D2D.Gameplay;
using D2D.Utilities;
using UnityEngine;

namespace D2D
{
    public abstract class OncePlayerInteractor : OnceObjectInteractorBase
    {
        protected override void CheckInteraction(GameObject other)
        {
            if (other.Is<PlayerCollider>() && !isObjectInside)
            {
                isObjectInside = true;
                OnPlayer(FindObjectOfType<Player>());
            }
        }

        protected abstract void OnPlayer(Player player);
    }
}