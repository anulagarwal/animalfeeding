using UnityEngine;
using System;
using System.Collections;
using System.Linq;

namespace D2D
{
    public enum InteractionType {Trigger, Collision, Both}
    
    public abstract class OnceObjectInteractorBase : MonoBehaviour
    {
        protected virtual InteractionType InteractionType => InteractionType.Trigger;

        protected bool isObjectInside;

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (InteractionType == InteractionType.Both || InteractionType == InteractionType.Collision)
                CheckInteraction(other.gameObject);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (InteractionType == InteractionType.Both || InteractionType == InteractionType.Trigger)
                CheckInteraction(other.gameObject);
        }

        protected abstract void CheckInteraction(GameObject other);
    }
}