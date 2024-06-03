namespace AARPG.Battle
{
    public class CharactorStatus
    {
        // 各ステータス群
        public float hp { get; private set; } = 50;
        public float mp { get; private set; } = 50;
        public float atk { get; private set; } = 10;
        public float mat { get; private set; } = 10;
        public float def { get; private set; } = 10;
        public float mde { get; private set; } = 10;
        public float agi { get; private set; } = 10;

        public CharactorStatus(float hp, float mp, float atk, float mat, float def, float mde, float agi)
        {
            this.hp = hp;
            this.mp = mp;
            this.atk = atk;
            this.mat = mat;
            this.def = def;
            this.mde = mde;
            this.agi = agi;
        }
    }
}