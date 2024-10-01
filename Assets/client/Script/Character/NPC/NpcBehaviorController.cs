using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehaviorController : MonoBehaviour, INpcBehavioeController
    {
        // TODO 条件を判定して各行動のOnNextを発火していく
        private Subject<Unit> _moveSubject;
        public IObservable<Unit> OnMoveAsObserble() { return _moveSubject; }
    }
}
