using AARPG.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AARPG.Battle.Gambit
{
    public sealed class GambitJudgeResult
    {
        public List<CharactorInfo> CharactorList { get; private set; }
        public string GambitDescription { get; private set; }

        public GambitJudgeResult(
            List<CharactorInfo> charactorList = null, 
            string gambitDeacription = null)
        {
            CharactorList = charactorList;
            GambitDescription = gambitDeacription;
        }
    }
}