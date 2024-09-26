using Character.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Character.Player
{
    public sealed class PlayerController : CommonCharacterController
    {
        [SerializeField] GameObject _player;

        private void Awake()
        {
            OnMoveDirectionAsObserble().Subscribe(x => OnMove(x)).AddTo(this);
        }
        private void OnMove(Vector3 forward)
        {
            if(forward == default)
            {
                return;
            }


        }
    }
}
