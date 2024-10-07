using Character.NPC.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UniRx;

namespace Character.NPC
{
    [RequireComponent(typeof(NpcCommonMoveController))]
    [RequireComponent(typeof(NpcAnimationController))]
    [RequireComponent(typeof(NpcBehaviorController))]
    public class NpcController : NpcCommonController
    {
        [SerializeField] private GameObject _npcObj;
        [SerializeField] private GameObject _target;
        private NpcBehaviorController _behaviorController;
        private NpcCommonMoveController _moveController;
        private NpcAnimationController _animationController;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _moveController = GetComponent<NpcCommonMoveController>();
            _animationController = GetComponent<NpcAnimationController>();
            _behaviorController = GetComponent<NpcBehaviorController>();

            base.Initialize(_behaviorController);
            _moveController.Initialize(_target.transform, _navMeshAgent, _animationController);
        }

        private void Start() 
        {
            OnMoveAsObserble()
                .Subscribe(_ => _moveController.SetOnMove(true))
                .AddTo(this);
        }
    }
}
