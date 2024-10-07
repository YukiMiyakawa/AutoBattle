using Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC.Common
{
    public class NpcCommonController : MonoBehaviour, INpcController
    {

        private INpcBehavioeController _npcBehavioeController;

        // TODO キャラクター生成クラスで生成時渡す
        public virtual void Initialize(INpcBehavioeController npcController)
        {
            _npcBehavioeController = npcController;
        }

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
        public IObservable<Unit> OnMoveAsObserble()
        {
            return _npcBehavioeController.OnMoveAsObserble();
        }
    }
}
