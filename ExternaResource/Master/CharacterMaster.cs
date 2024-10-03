using MasterMemory;
using MessagePack;

// �N���X��MemoryTable�A�g���r���[�g������i�����̕�����+MasterTable�Ƃ������O�̃N���X�����������j
// �N���X��MessagePackObject�A�g���r���[�g������
[MemoryTable("Character"), MessagePackObject(true)]
public sealed class CharacterMaster
{
    public CharacterMaster(long code, string name, string iconId)
    {
        Code = code;
        Name = name;
        IconId = iconId;
    }

    // �v���C�}���L�[�ɂ�PrimaryKey�A�g���r���[�g������
    [PrimaryKey]
    public long Code { get; set; }

    public string Name { get; set; }

    public string IconId { get; set; }
}