using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Character;
using MessagePack;
using MessagePack.Resolvers;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;

public static class BinaryGenerator
{
    [MenuItem("Tools/MasgterMemory/Generate Binary")]
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

        var readObjects = Resources.LoadAll("Assets/ExternaResource/Master/Csv");

        //�w�肵���f�B���N�g���ɓ����Ă���S�t�@�C�����擾(�q�f�B���N�g�����܂�)
        var directoryPath = "Assets/ExternaResource/Master/Csv";
        string[] filePathArray = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

        //�擾�����t�@�C���̒�����A�Z�b�g�������X�g�ɒǉ�����
        List<UnityEngine.Object> assetList = new List<UnityEngine.Object>();
        foreach (string filePath in filePathArray)
        {
            var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(filePath);
            if (asset != null)
            {
                assetList.Add(asset);
            }
        }

        foreach (var asset in assetList)
        {
            var name = asset.name;
            var csvFile = asset as UnityEngine.TextAsset;
            var csvDatas = new List<string[]>();

            if (csvFile == null)
            {
                continue;
            }

            var reader = new StringReader(csvFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                csvDatas.Add(line.Split(','));
            }

            if(name == "CharacterMaster")
            {
                var masters = new List<CharacterMaster>();
                for (var i = 0; i < csvDatas.Count; i++)
                {
                    if (i < 3)
                    {
                        continue;
                    }
                    masters.Add(new CharacterMaster(
                        Int64.Parse(csvDatas[i][0]),
                        csvDatas[i][1],
                        csvDatas[i][2]
                        ));
                }

                var databaseBuilder = new DatabaseBuilder();
                databaseBuilder.Append(masters);
                var binary = databaseBuilder.Build();

                BinarySave(binary, name);
            }
        }
    }

    private static void BinarySave(byte[] data, string name)
    {
        var path = $"Assets/ExternaResource/Master/Binary/{name}.bytes";
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        File.WriteAllBytes(path, data);
        AssetDatabase.Refresh();
    }
}

