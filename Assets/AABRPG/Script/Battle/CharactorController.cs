using AARPG.Scriptable.Battle;
using System.Collections.Generic;
using UnityEngine;

namespace AARPG.Battle
{
    [RequireComponent(typeof(CharactorInfo))]
    public class CharactorController : MonoBehaviour
    {
        [SerializeField] List<CharactorInfo> charactorStatuses = new List<CharactorInfo>();
        private CharactorInfo status;
        private List<GambitDefinitionData> gambitDefinitionDatas;

        private void Awake()
        {
            status = GetComponent<CharactorInfo>();
        }

        public void init()
        {
            // todo キャラステータス等設定
        }

    }

}

