using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

namespace Common
{
    public sealed class InputManager : MonoBehaviour
    {
        // �e�Q�[���p�b�h����̓��͂��܂Ƃ߁A�o�͂���ۂ̃��C���[�������s���N���X
        // UI���J���Ă��鎞�A�o�g����ʂ̎��Ȃ�
        // �Q�[���p�b�h���Ƀ{�^����������Ă��Ă߂�ǂ��������A�܂Ƃ߂���@��׋����Ȃ���Ƃ肠�����L�[�{�[�h���͂Ŏ���
        // https://nekojara.city/unity-input-system-intro


        public static InputManager Instance;
        private void Awake()
        {
            Instance = this;
        }


        /// <summary>
        /// ���ݓ��͂��󂯕t���Ă����ʂ̃��C���[
        /// </summary>
        public enum InputLayer
        {
            None,
            Battle,
            Town,
            UI
        }

        private InputLayer _layer;
        public InputLayer GetInputLayer => _layer;
        public void SetInputLayer(InputLayer layer)
        {
            _layer = layer;
        }


        /// <summary>
        /// ���͒�`�@����
        /// </summary>
        public IObservable<Unit> OnUpKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.UpArrow));
        }

        public IObservable<Unit> OnDownKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.DownArrow));
        }
        public IObservable<Unit> OnLeftKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.LeftArrow));
        }
        public IObservable<Unit> OnRightKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.RightArrow));
        }

        public IObservable<Vector3> OnDirectionKeyAsObserble()
        {
            return this.UpdateAsObservable()
                .Select(_ => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }

        public IObservable<Unit> OnJumpAsObserble()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.Space));
        }
    }
}
