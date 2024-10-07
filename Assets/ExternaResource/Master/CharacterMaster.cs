using MasterMemory;
using MessagePack;

// クラスにMemoryTableアトリビュートをつける（引数の文字列+MasterTableという名前のクラスが生成される）
// クラスにMessagePackObjectアトリビュートをつける
[MemoryTable("Character"), MessagePackObject(true)]
public sealed class CharacterMaster
{
    public CharacterMaster(long code, string name, string iconId)
    {
        Code = code;
        Name = name;
        IconId = iconId;
    }

    // プライマリキーにはPrimaryKeyアトリビュートをつける
    [PrimaryKey]
    public long Code { get; set; }

    public string Name { get; set; }

    public string IconId { get; set; }
}