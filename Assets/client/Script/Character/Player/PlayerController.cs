using Character.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

namespace Character.Player
{
    public sealed class PlayerController : CommonCharacterController
    {
        [Header("�L�����N�^�[")]
        [SerializeField] private GameObject _player;

        // �L�����N�^�[
        private Rigidbody _playerRigidbody;

        // �R���g���[���[
        private PlayerMoveController _playerMoveController;

        private void Awake()
        {
            _playerRigidbody = this.GetOrAddComponent<Rigidbody>();
            _playerMoveController = this.GetOrAddComponent<PlayerMoveController>();

            Initialize();
        }
        private void Start()
        {
            OnMoveDirectionAsObserble()
                .Subscribe(x => 
                {
                    _playerMoveController.OnMove(x);
                })
                .AddTo(this);

            OnJumpAsObserble()
                .Where(_ => BehaviorState != CharacterBehaviorState.Jump)
                .Subscribe(_ => 
                {
                    _playerMoveController.SetOnJump();
                    SetBehaviorState(CharacterBehaviorState.Jump);
                })
                .AddTo(this);
        }

        private void Initialize()
        {
            _playerMoveController.Initialize(_playerRigidbody, transform);
        }

        private void Update()
        {
            _playerMoveController.UpdateOnJump();
            UpdateBehaviorState();
        }

        private void UpdateBehaviorState()
        {
            // �W�����v��n�ʂɂ�����X�e�[�g�X�V
            if(BehaviorState == CharacterBehaviorState.Jump)
            {
                if (_playerMoveController.IsGrounded())
                {
                    SetBehaviorState(CharacterBehaviorState.None);
                }
            }
        }
    }
}
