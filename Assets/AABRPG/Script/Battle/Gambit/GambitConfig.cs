using AARPG.Scriptable.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AARPG.Battle.BattleConst;

namespace AARPG.Battle.Gambit
{
    public class GambitConfig
    {
        [SerializeField, Range(0, 5)]
        private Dictionary<GambitDefinitionModel, ActionType> gambitDic = new Dictionary<GambitDefinitionModel, ActionType>();
        private int charaId;
        private List<GambitDefinitionModel> gambitDefinitionModels = new List<GambitDefinitionModel>();
        public void Init(int charaId, List<GambitDefinitionModel> gambitDefinitionModels)
        {
            this.charaId = charaId;
            this.gambitDefinitionModels = gambitDefinitionModels;
        }
    }
}
