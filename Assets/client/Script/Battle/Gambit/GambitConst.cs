namespace AARPG.Battle.Gambit
{
    /// <summary>
    /// ガンビット条件に使用するenum定義
    /// </summary>
    public sealed class GambitConst
    {
        //********** 状態定義 **********
        // 数値　〇%以上等に使用
        public enum Number
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Ten = 10,
            Twenty = 20,
            Thirty = 30,
            Forty = 40,
            Fifty = 50,
            Sixty = 60,
            Seventy = 70,
            Eighty = 80,
            Ninety = 90,
            Hundred = 100
        }

        // 対象の参照ステータス値
        public enum Status
        {
            None,
            HP,
            MP,
            ATK,
            MAT,
            DEF,
            MDF,
            AGI
        }

        // 近く/遠い
        public enum Distance
        {
            None,
            Near,
            Far
        }

        // 比較演算子(以上、以下、最も多い、最も少ない）
        public enum ComparisionOperator
        {
            None,
            More,
            Less,
            Max,
            Min
        }


        // ステータス状態
        // 毒など


        //********** 対象定義 **********
        public enum TargetAttribute
        {
            None,
            Ally,
            Enemy
        }
    }
}
