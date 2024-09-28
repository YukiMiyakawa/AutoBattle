using Character.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

namespace Character.Player
{
    public sealed class PlayerController : PlayerCommonCharacterController
    {
        [Header("キャラクター")]
        [SerializeField] private GameObject _player;
        [Header("移動")]
        [SerializeField] private float _addHorizontalRate = 20f;
        [SerializeField] private float _addVerticalRate = 20f;
        [Header("ジャンプ")]
        [SerializeField] private float _addJumpForce = 1f;
        [SerializeField] private float _jumpAttenuationRate = 0.1f;
        [SerializeField] private float _checkDistance = 0.1f; // チェックする距離
        [SerializeField] private LayerMask _groundLayer; // 地面のレイヤー

        // キャラクター
        private Rigidbody _playerRigidbody;

        // ジャンプ
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

        // NOTE : ジャンプ時キャラ回転を防ぐためConstraints　Rotation　xとzに制限をかける
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

                    // ジャンプ方向ベロシティを0に
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
