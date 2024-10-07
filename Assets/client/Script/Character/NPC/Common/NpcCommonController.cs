using Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC.Common
{
    public class NpcCommonController : MonoBehaviour, INpcController
    {

        private INpcBehavioeController _npcBehavioeController;

        // TODO �L�����N�^�[�����N���X�Ő������n��
        public virtual void Initialize(INpcBehavioeController npcController)
        {
            _npcBehavioeController = npcController;
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
        public IObservable<Unit> OnMoveAsObserble()
        {
            return _npcBehavioeController.OnMoveAsObserble();
        }
    }
}
