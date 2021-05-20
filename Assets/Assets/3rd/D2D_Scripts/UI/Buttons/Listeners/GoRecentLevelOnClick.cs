using D2D.Core;
using D2D.Databases;
using D2D.UI;
using D2D.Utilities;
using D2D.Utils;

namespace D2D.UI
{
    public class GoRecentLevelOnClick : ButtonListener
    {
        protected override void OnClick()
        {
            var loader = this.FindLazy<SceneLoader>();
            var levelDb = this.FindLazy<LevelDatabase>();
            loader.LoadLevel(levelDb.RecentLevel);
        }
    }
}
