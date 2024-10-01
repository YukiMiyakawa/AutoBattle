using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehaviorController : MonoBehaviour, INpcBehavioeController
    {
        // TODO ğŒ‚ğ”»’è‚µ‚ÄŠes“®‚ÌOnNext‚ğ”­‰Î‚µ‚Ä‚¢‚­
        private Subject<Unit> _moveSubject;
        public IObservable<Unit> OnMoveAsObserble() { return _moveSubject; }
    }
}
