using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Common
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public bool IsCurrentAnimationState(string stateName)
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        }


        // NOTE hash’l‚Å“n‚·‚æ‚¤‚É‚·‚é
        public void SetAnimatorBool(string triggerName, bool value)
        {
            _animator.SetBool(triggerName, value);
        }

        public void SetAnimatorFloat(string triggerName, float value)
        {
            _animator.SetFloat(triggerName, value);
        }
    }
}
