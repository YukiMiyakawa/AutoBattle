using AARPG.Scriptable.Battle;
using System.Collections.Generic;

namespace AARPG.Battle.Gambit
{
    public sealed class GambitJudgeService : GambitJudgeLogic
    {
        /// <summary>
        /// HP/MP>�Z%
        /// </summary>
        protected override GambitJudgeResult StatusLessJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// HP/MP<�Z%
        /// </summary>
        protected override GambitJudgeResult StatusMoreJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// �ł�HP/MP/ATK/MAT/DEF/MDF/AGI������
        /// </summary>
        protected override GambitJudgeResult StatusMaxJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// �ł�HP/MP/ATK/MAT/DEF/MDF/AGI���Ⴂ
        /// </summary>
        protected override GambitJudgeResult StatusMinJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// �ł��߂�/�߂��ɁZ�̈ȏ�
        /// </summary>
        protected override GambitJudgeResult DistanceNearJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
        /// <summary>
        /// �ł�����
        /// </summary>
        protected override GambitJudgeResult DistanceFarJudge(GambitDefinitionData gambitDefinitionData, List<CharactorInfo> charactorList)
        {
            return null;
        }
    }
}
