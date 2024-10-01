using UnityEngine;

namespace Character.Player
{
    public class PlayerMoveController : MonoBehaviour
    {
        [Header("移動")]
        [SerializeField] private float _addHorizontalRate = 20f;
        [SerializeField] private float _addVerticalRate = 20f;
        [Header("ジャンプ")]
        [SerializeField] private float _addJumpForce = 1f;
        [SerializeField] private float _jumpAttenuationRate = 0.1f;
        [SerializeField] private float _checkDistance = 0.1f; // チェックする距離
        [SerializeField] private LayerMask _groundLayer; // 地面のレイヤー

        private PlayerAnimationController _playerAnimationController;

        // ジャンプ
        private float _jumpForceCash;
        private bool _onJump;
        public bool OnJump => _onJump;

        private Rigidbody _playerRigidbody;
        private Transform _transform;

        private void Awake()
        {
            _jumpForceCash = _addJumpForce;
            _playerAnimationController = this.GetComponent<PlayerAnimationController>();
        }


        public void Initialize(Rigidbody rb, Transform trn)
        {
            _playerRigidbody = rb;
            _transform = trn;
        }

        /// <summary>
        /// 歩き
        /// </summary>
        public void OnMove(Vector3 forward)
        {
            if (forward == default)
            {
                return;
            }

            var moveAmount = new Vector3(forward.x * _addHorizontalRate, forward.y, forward.z * _addVerticalRate);
            _playerRigidbody.AddForce(moveAmount);

            // 向きの変更
            var targetRotation = Quaternion.LookRotation(forward);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * 10f);

            _playerAnimationController.SetSpeedTrigger(forward.magnitude);
        }

        /// <summary>
        /// ジャンプフラグオン
        /// </summary>
        public void SetOnJump()
        {
            _playerAnimationController.SetJumpTrigger(true);
            _onJump = true;
        }

        /// <summary>
        /// 着地したかどうか
        /// </summary>
        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, _checkDistance)
                && !_onJump;
        }

        // NOTE : ジャンプ時キャラ回転を防ぐためConstraints　Rotationに制限をかける
        public void UpdateOnJump()
        {
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
                    _playerAnimationController.SetJumpTrigger(false);
                    _playerRigidbody.useGravity = false;
                }

                _jumpForceCash -= _jumpAttenuationRate;
                _playerRigidbody.AddForce(new Vector3(0, _jumpForceCash, 0));
            }
        }
    }
}
