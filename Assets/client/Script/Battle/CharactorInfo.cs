using UnityEngine;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Battle
{
    public sealed class CharactorInfo
    {
        public CharactorStatus Status { get; private set; }
        public TargetAttribute targetAttribute { get; private set; }

        [SerializeField] private TeamType teamType;
        public enum TeamType
        {
            A,
            B
        }

        public void init()
        {

        }

    }
}
