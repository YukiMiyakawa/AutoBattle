using AARPG.Scriptable.Battle;
using System.Collections.Generic;

namespace AARPG.Battle.Gambit
{
    public sealed class GambitDescriptionService : GambitJudgeLogic
    {
        /// <summary>
        /// HP/MP>〇%
        /// </summary>
        protected override GambitJudgeResult StatusLessJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// HP/MP<〇%
        /// </summary>
        protected override GambitJudgeResult StatusMoreJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// 最もHP/MP/ATK/MAT/DEF/MDF/AGIが高い
        /// </summary>
        protected override GambitJudgeResult StatusMaxJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// 最もHP/MP/ATK/MAT/DEF/MDF/AGIが低い
        /// </summary>
        protected override GambitJudgeResult StatusMinJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// 最も近い/近くに〇体以上
        /// </summary>
        protected override GambitJudgeResult DistanceNearJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// 最も遠い
        /// </summary>
        protected override GambitJudgeResult DistanceFarJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
    }
}
