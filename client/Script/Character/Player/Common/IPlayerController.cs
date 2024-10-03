using System;
using UniRx;
using UnityEngine;

namespace Character.Player.Common
{
    public interface IPlayerController

    {
        IObservable<Vector3> OnMoveDirectionAsObserble();
        IObservable<Unit> OnJumpAsObserble();
    }
}
