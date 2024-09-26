using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Character.Common
{
    public interface ICharacterController

    {
        IObservable<Vector3> OnMoveDirectionAsObserble();
        IObservable<Unit> OnJumpAsObserble();
    }
}
