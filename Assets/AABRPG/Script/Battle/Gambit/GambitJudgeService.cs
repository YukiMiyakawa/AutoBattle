using AARPG.Scriptable.Battle;
using System.Collections.Generic;

namespace AARPG.Battle.Gambit
{
    public sealed class GambitJudgeService : GambitJudgeLogic
    {
        /// <summary>
        /// HP/MP>ÅZ%
        /// </summary>
        protected override GambitJudgeResult StatusLessJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// HP/MP<ÅZ%
        /// </summary>
        protected override GambitJudgeResult StatusMoreJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// ç≈Ç‡HP/MP/ATK/MAT/DEF/MDF/AGIÇ™çÇÇ¢
        /// </summary>
        protected override GambitJudgeResult StatusMaxJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// ç≈Ç‡HP/MP/ATK/MAT/DEF/MDF/AGIÇ™í·Ç¢
        /// </summary>
        protected override GambitJudgeResult StatusMinJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// ç≈Ç‡ãﬂÇ¢/ãﬂÇ≠Ç…ÅZëÃà»è„
        /// </summary>
        protected override GambitJudgeResult DistanceNearJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// ç≈Ç‡âìÇ¢
        /// </summary>
        protected override GambitJudgeResult DistanceFarJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
    }
}
