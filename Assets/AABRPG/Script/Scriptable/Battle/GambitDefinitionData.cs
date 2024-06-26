using System.Collections.Generic;
using UnityEngine;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Scriptable.Battle
{
    [CreateAssetMenu(menuName = "GambitDefinition_Scriptable")]
    [System.SerializableAttribute]
    public sealed class GambitDefinitionTable : ScriptableObject
    {
        public List<GambitDefinitionData> gambitDefinitionDatas;
    }

    [System.Serializable]
    public sealed class GambitDefinitionData
    {
        public Number Number;
        public Status Status;
        public ComparisionOperator ComparisionOperator;
        public Distance Distance;
        public TargetAttribute TargetAttribute;
    }

}
