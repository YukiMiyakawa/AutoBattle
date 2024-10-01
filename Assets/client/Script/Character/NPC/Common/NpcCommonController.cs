using Common;
using System;
using UniRx;

namespace Character.NPC.Common
{
    public class NpcCommonController : INpcController
    {

        private INpcController _npcController;

        // TODO キャラクター生成クラスで生成時渡す
        public virtual void Initialize(INpcController npcController)
        {
            _npcController = npcController;
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
        public IObservable<Unit> OnMovenAsObserble()
        {
            return _npcController.OnMovenAsObserble();
        }
    }
}
