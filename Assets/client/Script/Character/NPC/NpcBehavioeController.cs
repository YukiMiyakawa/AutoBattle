using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehavioeController : MonoBehaviour, INpcBehavioeController
    {
        // TODO �����𔻒肵�Ċe�s����OnNext�𔭉΂��Ă���
        private Subject<Unit> _jumpSubject;
        public IObservable<Unit> OnJumpAsObserble() { return _jumpSubject; }
    }
}
