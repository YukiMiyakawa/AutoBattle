using Example;
using MessagePack;
using MessagePack.Resolvers;
using UnityEditor;
using UnityEngine;

public static class BinaryLoader
{
    [MenuItem("Example/Load Binary")]
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

        // ���[�h�i�e�X�g�p��AssetDatabase���g���Ă��邪���ۂɂ�Addressable�ȂǂŁj
        var path = "Assets/AABRPG/Script/Master/StageMaster.bytes";
        var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
        var binary = asset.bytes;

        // MemoryDatabase���o�C�i������쐬
        var memoryDatabase = new MemoryDatabase(binary);
        // �e�[�u������f�[�^������
        var stage = memoryDatabase.StageMasterTable.FindById("stage-01-002");
        Debug.Log(stage.Name); // �����̎��n��
    }
}