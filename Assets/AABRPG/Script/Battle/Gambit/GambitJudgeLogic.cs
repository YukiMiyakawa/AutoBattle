using AARPG.Scriptable.Battle;
using System.Collections.Generic;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Battle.Gambit
{
    public class GambitJudgeLogic
    {
        /// <summary>
        /// �K���r�b�g���胁�\�b�h
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
        /// �ȉ��p�^�[���̏����𔻒�
        /// �E�ł�HP/MP/ATK/MAT/DEF/MDF/AGI������or�Ⴂ
        /// �EHP/MP>�Z%��
        /// �EHP/MP���Z%��
        /// </summary>
        private GambitJudgeResult StatusJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            switch (gambitDefinitionData.ComparisionOperator)
            {
                case ComparisionOperator.Less:
                    //HP/MP>�Z%
                    return StatusLessJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.More:
                    //HP/MP<�Z%
                    return StatusMoreJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.Max:
                    //�ł�HP/MP/ATK/MAT/DEF/MDF/AGI������
                    return StatusMaxJudge(gambitDefinitionData, charactorList);
                case ComparisionOperator.Min:
                    //�ł�HP/MP/ATK/MAT/DEF/MDF/AGI���Ⴂ
                    return StatusMinJudge(gambitDefinitionData, charactorList);
                default: 
                    return null;
            }
        }

        /// <summary>
        /// �ȉ��p�^�[���̏����𔻒�
        /// �E�߂��ɁZ�̈ȏ�
        /// �E�ł��߂�/����
        /// </summary>
        private GambitJudgeResult DistanceJudge(GambitDefinitionData gambitDefinitionData, List<CharactorStatus> charactorList)
        {
            switch (gambitDefinitionData.Distance)
            {
                case Distance.Near:
                    //�ł��߂�/�߂��ɁZ�̈ȏ�
                    return DistanceNearJudge(gambitDefinitionData, charactorList);
                case Distance.Far:
                    //�ł�����
                    return DistanceFarJudge(gambitDefinitionData, charactorList);
                default:
                    return null;
            }
        }

        // ����̖�����_���Ă���A�ŏ�ԂȂǂ𔻒肷�郁�\�b�h�͌�ł���

        /// <summary>
        /// ������̏����ɂ������Ȃ��ꍇ
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

