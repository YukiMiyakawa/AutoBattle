using Character.NPC.Common;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehaviorController : MonoBehaviour, INpcBehavioeController
    {
        // All Temporary Process
        [SerializeField] private Transform _npcTransform;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _searchDistance = 3f;
        [SerializeField] private float _frontDistance = 1f;
        
        // BehaviorSubject
        private Subject<Unit> _moveSubject = new Subject<Unit>();
        public IObservable<Unit> OnMoveAsObserble() { return _moveSubject; }

        private void Awake()
        {
            // move start or stop 
            Observable.EveryUpdate()
                .Select(_ => 
                        Vector3.Distance(_npcTransform.position, _playerTransform.position) < _searchDistance
                        && Vector3.Distance(_npcTransform.position, _playerTransform.position) > _frontDistance
                    )
                .DistinctUntilChanged()
                .Where(isClose => isClose)
                .Subscribe(_ =>
                {
                    _moveSubject.OnNext(Unit.Default);
                })
                .AddTo(this);
        }
    }
}
