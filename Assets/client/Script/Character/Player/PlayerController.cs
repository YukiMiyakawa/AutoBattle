using Character.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

namespace Character.Player
{
    public sealed class PlayerController : PlayerCommonCharacterController
    {
        [Header("�L�����N�^�[")]
        [SerializeField] private GameObject _player;
        [Header("�ړ�")]
        [SerializeField] private float _addHorizontalRate = 20f;
        [SerializeField] private float _addVerticalRate = 20f;
        [Header("�W�����v")]
        [SerializeField] private float _addJumpForce = 1f;
        [SerializeField] private float _jumpAttenuationRate = 0.1f;
        [SerializeField] private float _checkDistance = 0.1f; // �`�F�b�N���鋗��
        [SerializeField] private LayerMask _groundLayer; // �n�ʂ̃��C���[

        // �L�����N�^�[
        private Rigidbody _playerRigidbody;

        // �W�����v
        private float _jumpForceCash;
        private bool _onJump;
        private bool _isGrounded;

        private void Awake()
        {
            _playerRigidbody = this.GetOrAddComponent<Rigidbody>();
            _jumpForceCash = _addJumpForce;
        }
        private void Start()
        {
            OnMoveDirectionAsObserble().Subscribe(x => OnMove(x)).AddTo(this);
            OnJumpAsObserble().Where(_ => BehaviorState != CharacterBehaviorState.Jump).Subscribe(_ => OnJump()).AddTo(this);
        }

        private void OnMove(Vector3 forward)
        {
            if(forward == default)
            {
                return;
            }

            var moveAmount = new Vector3(forward.x * _addHorizontalRate, forward.y, forward.z * _addVerticalRate);
            _playerRigidbody.AddForce(moveAmount);
        }

        private void OnJump()
        {
            _onJump = true;
        }

        private void Update()
        {
            UpdateOnJump();
        }

        // NOTE : �W�����v���L������]��h������Constraints�@Rotation�@x��z�ɐ�����������
        private void UpdateOnJump()
        {
            if (_jumpForceCash == _addJumpForce && BehaviorState == CharacterBehaviorState.Jump)
            {
                _isGrounded = Physics.Raycast(transform.position, Vector3.down, _checkDistance);
                if (_isGrounded)
                {
                    SetBehaviorState(CharacterBehaviorState.None);
                }
            }

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
                    SetBehaviorState(CharacterBehaviorState.Jump);
                }

                _jumpForceCash -= _jumpAttenuationRate;
                _playerRigidbody.AddForce(new Vector3(0, _jumpForceCash, 0));
            }
        }
    }
}
