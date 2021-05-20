using D2D.Core;
using D2D.UI;
using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.UI
{
    [RequireComponent(typeof(DButton))]
    public class ReloadOnClick : ButtonListener
    {
        protected override void OnClick()
        {
            var loader = this.FindLazy<SceneLoader>();
            loader.ReloadCurrentScene();
        }

    }
}
