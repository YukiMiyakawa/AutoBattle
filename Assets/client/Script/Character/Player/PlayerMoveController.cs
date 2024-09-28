using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character.Common.CommonCharacterController;

namespace Character.Player
{
    public class PlayerMoveController : MonoBehaviour
    {
        [Header("�ړ�")]
        [SerializeField] private float _addHorizontalRate = 20f;
        [SerializeField] private float _addVerticalRate = 20f;
        [Header("�W�����v")]
        [SerializeField] private float _addJumpForce = 1f;
        [SerializeField] private float _jumpAttenuationRate = 0.1f;
        [SerializeField] private float _checkDistance = 0.1f; // �`�F�b�N���鋗��
        [SerializeField] private LayerMask _groundLayer; // �n�ʂ̃��C���[

        // �W�����v
        private float _jumpForceCash;
        private bool _onJump;
        public bool OnJump => _onJump;

        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            _jumpForceCash = _addJumpForce;
        }


        public void Initialize(Rigidbody rb)
        {
            _playerRigidbody = rb;
        }

        /// <summary>
        /// ����
        /// </summary>
        public void OnMove(Vector3 forward)
        {
            if (forward == default)
            {
                return;
            }

            var moveAmount = new Vector3(forward.x * _addHorizontalRate, forward.y, forward.z * _addVerticalRate);
            _playerRigidbody.AddForce(moveAmount);
        }

        /// <summary>
        /// �W�����v�t���O�I��
        /// </summary>
        public void SetOnJump()
        {
            _onJump = true;
        }

        /// <summary>
        /// ���n�������ǂ���
        /// </summary>
        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, _checkDistance)
                && !_onJump;
        }

        // NOTE : �W�����v���L������]��h������Constraints�@Rotation�ɐ�����������
        public void UpdateOnJump()
        {
            if (_onJump)
            {
                if (_jumpForceCash <= 0)
                {
                    _playerRigidbody.useGravity = true;
                    _jumpForceCash = _addJumpForce;
                    _onJump = false;

                    // �W�����v�����x���V�e�B��0��
                    var tmpVelosity = _playerRigidbody.velocity;
                    tmpVelosity.y = 0;
                    _playerRigidbody.velocity = tmpVelosity;

                    return;
                }
                else if (_jumpForceCash == _addJumpForce)
                {
                    _playerRigidbody.useGravity = false;
                }

                _jumpForceCash -= _jumpAttenuationRate;
                _playerRigidbody.AddForce(new Vector3(0, _jumpForceCash, 0));
            }
        }
    }
}