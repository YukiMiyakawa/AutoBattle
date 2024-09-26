using Character.Common;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Character.Common
{
    public class CommonCharacterController : MonoBehaviour, ICharacterController
    {
        public IObservable<Vector3> OnMoveDirectionAsObserble()
        {
            return InputManager.Instance.OnDirectionKeyAsObserble();
        }

        public IObservable<Unit> OnJumpAsObserble()
        {
            return InputManager.Instance.OnJumpAsObserble();
        }
    }
}
