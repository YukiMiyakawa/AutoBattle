using System;
using UniRx;

namespace Character.NPC.Common
{
    public interface INpcBehavioeController
    {
        IObservable<Unit> OnJumpAsObserble();
    }
}
