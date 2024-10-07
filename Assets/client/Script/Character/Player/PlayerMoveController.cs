using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Player
{
    public class PlayerMoveController : MonoBehaviour
    {
        [Header("�ړ�")]
        [SerializeField] private float _addHorizontalRate = 20f;
        [SerializeField] private float _addVerticalRate = 20f;
        [Header("�W�����v")]
        [SerializeField] private float _addJumpForce = 1f;
        [SerializeField] private float _checkDistance = 0.1f; // �`�F�b�N���鋗��
        [SerializeField] private LayerMask _groundLayer; // �n�ʂ̃��C���[

        private PlayerAnimationController _playerAnimationController;

        // �ړ�
        private bool _canMove = true;
        public float MoveAmount { get; private set; }

        // �W�����v
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
        /// ����
        /// </summary>
        public void OnMove(Vector3 forward)
        {
            if(MoveAmount == default && forward == default || !_canMove)
            {
                return;
            }
            
            // �ړ��A�j���[�V����
            MoveAmount = forward.magnitude;
            _playerAnimationController.SetSpeedTrigger(MoveAmount);

            // �ړ�
            var addVelosity = new Vector3(forward.x * _addHorizontalRate, forward.y, forward.z * _addVerticalRate);
            _playerRigidbody.AddForce(addVelosity);

            // �����̕ύX
            if (forward == default) return;
            var targetRotation = Quaternion.LookRotation(forward);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        /// <summary>
        /// �W�����v�t���O�I��
        /// </summary>
        public void OnJump()
        {
            _onJump = true;
            JumpAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }

        /// <summary>
        /// �W�����v����
        /// </summary>
        public async UniTask JumpAsync(CancellationToken token)
        {
            _onJump = true;
            _playerAnimationController.SetJumpTrigger();

            // �W�����v�J�n�܂�await
            _canMove = false;
            _playerRigidbody.velocity = Vector3.zero;
            await UniTask.WaitUntil(() => _playerAnimationController.IsJumpStart, cancellationToken: token);
            _canMove = true;
            
            // �͂�������
            _playerRigidbody.AddForce(Vector3.up * _addJumpForce, ForceMode.Impulse);

            // �W�����v�J�n�܂őҋ@
            await UniTask.WaitUntil(() => _playerRigidbody.velocity.y > 0, cancellationToken: token);

            // �W�����v���͑ҋ@
            await UniTask.WaitUntil(() => _playerRigidbody.velocity.y <= 0, cancellationToken: token);

            // NOTE : ���n�܂łɋ󒆍U�����s����悤�ɂ���
            //        �󒆍U���\���ǂ����̔���ǉ�

            // ���n�܂őҋ@
            await UniTask.WaitUntil(() => IsGrounded(), cancellationToken: token);
            _playerAnimationController.Resume();

            //���n���쒆�͈ړ����Ȃ�
            _canMove = false;
            _playerRigidbody.velocity = Vector3.zero;
            await UniTask.WaitUntil(() => !_playerAnimationController.IsJumpState(), cancellationToken: token);
            _canMove = true;
            
            _playerAnimationController.ResetIsJumpFlg();
            _onJump = false; // �W�����v�I��
        }

        /// <summary>
        /// ���n�������ǂ���
        /// </summary>
        public bool IsGrounded()
        {
            return Physics.Raycast(_transform.position, Vector3.down, _checkDistance);
        }
    }
}
