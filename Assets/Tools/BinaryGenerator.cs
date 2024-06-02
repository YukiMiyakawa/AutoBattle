using System.IO;
using Example;
using MessagePack;
using MessagePack.Resolvers;
using UnityEditor;
using UnityEngine.Timeline;

public static class BinaryGenerator
{
    [MenuItem("Example/Generate Binary")]
    private static void Run()
    {
        // MessagePackの初期化（ボイラープレート）
        var messagePackResolvers = CompositeResolver.Create(
            MasterMemoryResolver.Instance, // 自動生成されたResolver（Namespaceごとに作られる）
            GeneratedResolver.Instance, // 自動生成されたResolver
            StandardResolver.Instance // MessagePackの標準Resolver
        );
        var options = MessagePackSerializerOptions.Standard.WithResolver(messagePackResolvers);
        MessagePackSerializer.DefaultOptions = options;

        // Csvとかからデータを入れる（今回はテストのためコードで入れる）
        var stageMasters = new StageMaster[]
        {
            new("stage-01-001", "初心者の森", 100, "enemy-01-001", 100, "resource-01-001"),
            new("stage-01-002", "迷いの湿地帯", 200, "enemy-01-002", 200, "resource-01-002"),
            new("stage-01-003", "炎の山脈", 400, "enemy-01-003", 400, "resource-01-003"),
            new("stage-02-001", "氷結の洞窟", 500, "enemy-02-001", 500, "resource-02-001"),
            new("stage-02-002", "幽霊の墓地", 600, "enemy-02-002", 600, "resource-02-002"),
            new("stage-02-003", "竜の城塞", 1000, "enemy-02-003", 1000, "resource-02-003")
        };

        // DatabaseBuilderを使ってバイナリデータを生成する
        var databaseBuilder = new DatabaseBuilder();
        databaseBuilder.Append(stageMasters);
        var binary = databaseBuilder.Build();

        // できたバイナリは永続化しておく
        var path = "Assets/AABRPG/Script/Master/StageMaster.bytes";
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        File.WriteAllBytes(path, binary);
        AssetDatabase.Refresh();
    }
}