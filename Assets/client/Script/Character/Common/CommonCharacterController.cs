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
        /// <summary>
        /// キャラクター行動ステート
        /// </summary>
        public enum CharacterBehaviorState
        {
            None,
            Walk,
            Run,
            Jump
        }

        private CharacterBehaviorState _behaviorState;
        public CharacterBehaviorState BehaviorState => _behaviorState;
        public void SetBehaviorState(CharacterBehaviorState state)
        {
            _behaviorState = state;
        }


        /// <summary>
        /// 入力定義
        /// </summary>
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
