using UnityEngine;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Battle
{
    public class CharactorInfo
    {
        // 各ステータス群
        public float hp { get; private set; } = 50;
        public float mp { get; private set; } = 50;
        public float atk { get; private set; } = 10;
        public float mat { get; private set; } = 10;
        public float def { get; private set; } = 10;
        public float mde { get; private set; } = 10;
        public float agi { get; private set; } = 10;


        public void init()
        {
            // Todo マスタやプレイヤーデータからステータスと所属チームを定義
        }

    }
}

