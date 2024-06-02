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
        // MessagePack�̏������i�{�C���[�v���[�g�j
        var messagePackResolvers = CompositeResolver.Create(
            MasterMemoryResolver.Instance, // �����������ꂽResolver�iNamespace���Ƃɍ����j
            GeneratedResolver.Instance, // �����������ꂽResolver
            StandardResolver.Instance // MessagePack�̕W��Resolver
        );
        var options = MessagePackSerializerOptions.Standard.WithResolver(messagePackResolvers);
        MessagePackSerializer.DefaultOptions = options;

        // Csv�Ƃ�����f�[�^������i����̓e�X�g�̂��߃R�[�h�œ����j
        var stageMasters = new StageMaster[]
        {
            new("stage-01-001", "���S�҂̐X", 100, "enemy-01-001", 100, "resource-01-001"),
            new("stage-01-002", "�����̎��n��", 200, "enemy-01-002", 200, "resource-01-002"),
            new("stage-01-003", "���̎R��", 400, "enemy-01-003", 400, "resource-01-003"),
            new("stage-02-001", "�X���̓��A", 500, "enemy-02-001", 500, "resource-02-001"),
            new("stage-02-002", "�H��̕�n", 600, "enemy-02-002", 600, "resource-02-002"),
            new("stage-02-003", "���̏��", 1000, "enemy-02-003", 1000, "resource-02-003")
        };

        // DatabaseBuilder���g���ăo�C�i���f�[�^�𐶐�����
        var databaseBuilder = new DatabaseBuilder();
        databaseBuilder.Append(stageMasters);
        var binary = databaseBuilder.Build();

        // �ł����o�C�i���͉i�������Ă���
        var path = "Assets/AABRPG/Script/Master/StageMaster.bytes";
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        File.WriteAllBytes(path, binary);
        AssetDatabase.Refresh();
    }
}