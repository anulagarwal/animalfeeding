using D2D.Core;
using D2D.Gameplay;
using D2D.Utilities;
using UnityEngine;

namespace D2D.Environment
{
    public class Obstacle : OncePlayerInteractor
    {
        protected override void OnPlayer(Player player)
        {
            this.FindLazy<GameStateMachine>().Push(new LoseState());
        }
    }
}