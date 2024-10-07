using Character.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;
using Character.Player.Common;

namespace Character.Player
{
    public sealed class PlayerController : PlayerCommonController
    {
        [Header("キャラクター")]
        [SerializeField] private GameObject _player;

        // キャラクター
        private Rigidbody _playerRigidbody;

        // コントローラー
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
                    _playerMoveController.JumpAsync(this.GetCancellationTokenOnDestroy()).Forget();
                })
                .AddTo(this);
        }

        private void Initialize()
        {
            _playerMoveController.Initialize(_playerRigidbody, transform);
        }

        private void Update()
        {
            UpdateBehaviorState();
        }

        private void UpdateBehaviorState()
        {
            if(_playerMoveController.IsOnJump)
            {
                SetBehaviorState(CharacterBehaviorState.Jump);
                return;
            }

            if(_playerMoveController.MoveAmount > 0.05f)
            {
                SetBehaviorState(CharacterBehaviorState.Walk);
                return;
            }

            SetBehaviorState(CharacterBehaviorState.None);
        }
    }
}
