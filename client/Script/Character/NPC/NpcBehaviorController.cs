using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehaviorController : MonoBehaviour, INpcBehavioeController
    {
        // TODO �����𔻒肵�Ċe�s����OnNext�𔭉΂��Ă���
        private Subject<Unit> _moveSubject;
        public IObservable<Unit> OnMoveAsObserble() { return _moveSubject; }
    }
}
