using System.Threading;
using Cysharp.Threading.Tasks;
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
        [SerializeField] private float _checkDistance = 0.1f; // チェックする距離
        [SerializeField] private LayerMask _groundLayer; // 地面のレイヤー

        private PlayerAnimationController _playerAnimationController;

        // 移動
        private bool _canMove = true;
        public float MoveAmount { get; private set; }

        // ジャンプ
        private bool _onJump;
        public bool IsOnJump => _onJump;

        // Player
        private Rigidbody _playerRigidbody;
        private Transform _transform;

        private void Awake()
        {
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
            if(MoveAmount == default && forward == default || !_canMove)
            {
                return;
            }
            
            // 移動アニメーション
            MoveAmount = forward.magnitude;
            _playerAnimationController.SetSpeedTrigger(MoveAmount);

            // 移動
            var addVelosity = new Vector3(forward.x * _addHorizontalRate, forward.y, forward.z * _addVerticalRate);
            _playerRigidbody.AddForce(addVelosity);

            // 向きの変更
            if (forward == default) return;
            var targetRotation = Quaternion.LookRotation(forward);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        /// <summary>
        /// ジャンプフラグオン
        /// </summary>
        public void OnJump()
        {
            _onJump = true;
            JumpAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }

        /// <summary>
        /// ジャンプ処理
        /// </summary>
        public async UniTask JumpAsync(CancellationToken token)
        {
            _onJump = true;
            _playerAnimationController.SetJumpTrigger();

            // ジャンプ開始までawait
            _canMove = false;
            _playerRigidbody.velocity = Vector3.zero;
            await UniTask.WaitUntil(() => _playerAnimationController.IsJumpStart, cancellationToken: token);
            _canMove = true;
            
            // 力を加える
            _playerRigidbody.AddForce(Vector3.up * _addJumpForce, ForceMode.Impulse);

            // ジャンプ開始まで待機
            await UniTask.WaitUntil(() => _playerRigidbody.velocity.y > 0, cancellationToken: token);

            // ジャンプ中は待機
            await UniTask.WaitUntil(() => _playerRigidbody.velocity.y <= 0, cancellationToken: token);

            // NOTE : 着地までに空中攻撃を行えるようにする
            //        空中攻撃可能かどうかの判定追加

            // 着地まで待機
            await UniTask.WaitUntil(() => IsGrounded(), cancellationToken: token);
            _playerAnimationController.Resume();

            //着地動作中は移動しない
            _canMove = false;
            _playerRigidbody.velocity = Vector3.zero;
            await UniTask.WaitUntil(() => !_playerAnimationController.IsJumpState(), cancellationToken: token);
            _canMove = true;
            
            _playerAnimationController.ResetIsJumpFlg();
            _onJump = false; // ジャンプ終了
        }

        /// <summary>
        /// 着地したかどうか
        /// </summary>
        public bool IsGrounded()
        {
            return Physics.Raycast(_transform.position, Vector3.down, _checkDistance);
        }
    }
}
