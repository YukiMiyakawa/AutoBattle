using System.Collections.Generic;
using UnityEngine;

namespace AARPG.Scriptable.Charactor
{
    [CreateAssetMenu(menuName = "Master/Create CharactorMansterTable", fileName = "CharactorMansterTable")]
    [System.SerializableAttribute]
    public sealed class CharactorMansterTable : ScriptableObject
    {
        public List<CharactorManster> CharactorMansters;
    }

    [System.Serializable]
    public sealed class CharactorManster
    {
        public int Id;
    }

    [CreateAssetMenu(menuName = "Master/Create CharactorStatusMansterTable", fileName = "CharactorStatusMansterTable")]
    [System.SerializableAttribute]
    public sealed class CharactorStatusMansterTable : ScriptableObject
    {
        public List<CharactorStatusManster> CharactorMansters;
    }

    [System.Serializable]
    public sealed class CharactorStatusManster
    {
        public int Id;
        public float hp = 50;
        public float mp = 50;
        public float atk = 10;
        public float mat = 10;
        public float def = 10;
        public float mde = 10;
        public float agi = 10;
    }
}
