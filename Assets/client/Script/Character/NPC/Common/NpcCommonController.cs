using Common;
using System;
using UniRx;

namespace Character.NPC.Common
{
    public class NpcCommonController : INpcController
    {

        private INpcController _npcController;

        // TODO �L�����N�^�[�����N���X�Ő������n��
        public virtual void Initialize(INpcController npcController)
        {
            _npcController = npcController;
        }

        /// <summary>
        /// �L�����N�^�[�s���X�e�[�g
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
        /// ���͒�`
        /// </summary>
        public IObservable<Unit> OnMovenAsObserble()
        {
            return _npcController.OnMovenAsObserble();
        }
    }
}
