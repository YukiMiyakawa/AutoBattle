namespace AARPG.Battle.Gambit
{
    /// <summary>
    /// �K���r�b�g�����Ɏg�p����enum��`
    /// </summary>
    public sealed class GambitConst
    {
        //********** ��Ԓ�` **********
        // ���l�@�Z%�ȏ㓙�Ɏg�p
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

        // �Ώۂ̎Q�ƃX�e�[�^�X�l
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

        // �߂�/����
        public enum Distance
        {
            None,
            Near,
            Far
        }

        // ��r���Z�q(�ȏ�A�ȉ��A�ł������A�ł����Ȃ��j
        public enum ComparisionOperator
        {
            None,
            More,
            Less,
            Max,
            Min
        }


        // �X�e�[�^�X���
        // �łȂ�


        //********** �Ώے�` **********
        public enum TargetAttribute
        {
            None,
            Ally,
            Enemy
        }
    }
}
