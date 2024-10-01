using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehavioeController : MonoBehaviour, INpcBehavioeController
    {
        // TODO 条件を判定して各行動のOnNextを発火していく
        private Subject<Unit> _jumpSubject;
        public IObservable<Unit> OnJumpAsObserble() { return _jumpSubject; }
    }
}
