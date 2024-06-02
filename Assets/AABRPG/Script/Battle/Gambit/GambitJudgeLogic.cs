using AARPG.Scriptable.Battle;
using System.Collections.Generic;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Battle.Gambit
{
    public class GambitJudgeLogic
    {
        /// <summary>
        /// ガンビット判定メソッド
        /// </summary>
        public GambitJudgeResult GambitJudge(GambitDefinitionModel gambitDefinitionModel, List<CharactorStatus> charactorList)
        {
            var gambit = gambitDefinitionModel.GambitDefinitionData;

            if(gambit == null)
            {
                return null;
            }

            GambitJudgeResult gambitJudgeResult = null;

            if (gambit.Status != Status.None)
            {
                gambitJudgeResult = StatusJudge(gambit, charactorList);
            }
            else if(gambit.Distance != Distance.None)
            {
                gambitJudgeResult = DistanceJudge(gambit, charactorList);
            }

            if (gambitJudgeResult != null) return gambitJudgeResult;
            return DefaultJudge(gambit, charactorList);
        }

        /// <summary>
        /// 以下パターンの条件を判定
        /// ・最もHP/MP/ATK/MAT/DEF/MDF/AGIが高いor低い
        /// ・HP/MP>〇%の
        /// ・HP/MP＜〇%の
        /// </summary>
        private GambitJudgeResult StatusJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            switch (gambitDefinitionData.ComparisionOperator)
            {
                case ComparisionOperator.Less:
                    //HP/MP>〇%
                    return StatusLessJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.More:
                    //HP/MP<〇%
                    return StatusMoreJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.Max:
                    //最もHP/MP/ATK/MAT/DEF/MDF/AGIが高い
                    return StatusMaxJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.Min:
                    //最もHP/MP/ATK/MAT/DEF/MDF/AGIが低い
                    return StatusMinJudge(gambitDefinitionData, charactorList);
                default: 
                    return null;
            }
        }

        /// <summary>
        /// 以下パターンの条件を判定
        /// ・近くに〇体以上
        /// ・最も近い/遠い
        /// </summary>
        private GambitJudgeResult DistanceJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            switch (gambitDefinitionData.Distance)
            {
                case Distance.Near:
                    //最も近い/近くに〇体以上
                    return DistanceNearJudge(gambitDefinitionData, charactorList);
                case Distance.Far:
                    //最も遠い
                    return DistanceFarJudge(gambitDefinitionData, charactorList);
                default:
                    return null;
            }
        }

        // 特定の味方を狙っている、毒状態などを判定するメソッドは後でつくる

        /// <summary>
        /// いずれの条件にも満たない場合
        /// </summary>
        private GambitJudgeResult DefaultJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }

        protected virtual GambitJudgeResult StatusLessJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
        protected virtual GambitJudgeResult StatusMoreJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
        protected virtual GambitJudgeResult StatusMaxJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
        protected virtual GambitJudgeResult StatusMinJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
        protected virtual GambitJudgeResult DistanceNearJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
        protected virtual GambitJudgeResult DistanceFarJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            return null;
        }
    }
}

