using Character.NPC.Common;
using System;
using UniRx;
using UnityEngine;

namespace Character.NPC
{
    public class NpcBehavioeController : MonoBehaviour, INpcBehavioeController
    {
        // TODO ğŒ‚ğ”»’è‚µ‚ÄŠes“®‚ÌOnNext‚ğ”­‰Î‚µ‚Ä‚¢‚­
        private Subject<Unit> _jumpSubject;
        public IObservable<Unit> OnJumpAsObserble() { return _jumpSubject; }
    }
}
