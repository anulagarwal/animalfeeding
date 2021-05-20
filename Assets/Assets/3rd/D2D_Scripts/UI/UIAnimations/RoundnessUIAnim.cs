using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace D2D.UI
{
    public class RoundnessUIAnim : UIAnim
    {
        [SerializeField] private float to = 12;
        [SerializeField] private List<UniformModifier> targets;

        private float originalRadius;

        private void OnDrawGizmosSelected()
        {
            if (targets == null || targets.Count == 0)
                targets = GetComponentsInChildren<UniformModifier>().ToList();
        }

        private void Awake()
        {
            originalRadius = targets[0].Radius;
        }
        
        protected override void Positive()
        {
            foreach (var t in targets)
            {
                DOTween.To(() => t.Radius,
                    x => t.Radius = x, to,
                    duration);
            }
        }

        protected override void Negative()
        {
            foreach (var t in targets)
            {
                DOTween.To(() => t.Radius,
                    x => t.Radius = x, originalRadius,
                    duration);
            }
        }
    }
}