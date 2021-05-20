using System;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace D2D.Animations
{
    /// <summary>
    /// TODO: Add mesh fade!
    /// </summary>
    public class FadeAnimation : DAnimation<Color, Color, ColorOptions>
    {
        protected override TweenerCore<Color, Color, ColorOptions> CreateAnimation()
        {
            TweenerCore<Color, Color, ColorOptions> anim = null;
            
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                anim = spriteRenderer.DOFade(To.RandomFloat(), CalculatedDuration);

            var maskable = GetComponent<MaskableGraphic>();
            if (maskable != null)
                anim = maskable.DOFade(To.RandomFloat(), CalculatedDuration);

            if (anim == null)
            {
                throw new Exception("Can`t fade because there is no maskable or SpriteRenderer!");
            }

            return anim;
        }
    }
}