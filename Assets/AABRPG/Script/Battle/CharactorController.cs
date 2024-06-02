using AARPG.Scriptable.Battle;
using System.Collections.Generic;
using UnityEngine;

namespace AARPG.Battle
{
    [RequireComponent(typeof(CharactorStatus))]
    public class CharactorController : MonoBehaviour
    {
        [SerializeField] List<CharactorStatus> charactorStatuses = new List<CharactorStatus>();
        private CharactorStatus status;
        private List<GambitDefinitionData> gambitDefinitionDatas;

        private void Awake()
        {
            status = GetComponent<CharactorStatus>();
        }

        public void init()
        {
            // todo キャラステータス等設定
        }

    }

}

