using System;
using UniRx;

namespace Character.NPC.Common
{
    public interface INpcController
    {
        IObservable<Unit> OnMovenAsObserble();
    }
}
