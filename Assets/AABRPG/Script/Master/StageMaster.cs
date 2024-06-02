using MasterMemory;
using MessagePack;

// �N���X��MemoryTable�A�g���r���[�g������i�����̕�����+MasterTable�Ƃ������O�̃N���X�����������j
// �N���X��MessagePackObject�A�g���r���[�g������
[MemoryTable("Stage"), MessagePackObject(true)]
public sealed class StageMaster
{
    public StageMaster(string id, string name, int difficulty, string enemyGroupId, int exp, string resourceId)
    {
        Id = id;
        Name = name;
        Difficulty = difficulty;
        EnemyGroupId = enemyGroupId;
        Exp = exp;
        ResourceId = resourceId;
    }

    // �v���C�}���L�[�ɂ�PrimaryKey�A�g���r���[�g������
    [PrimaryKey]
    public string Id { get; }

    public string Name { get; }

    public int Difficulty { get; }

    public string EnemyGroupId { get; }

    public int Exp { get; }

    public string ResourceId { get; }
}