// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;
using Character.Tables;

namespace Character
{
   public sealed class MemoryDatabase : MemoryDatabaseBase
   {
        public CharacterMasterTable CharacterMasterTable { get; private set; }

        public MemoryDatabase(
            CharacterMasterTable CharacterMasterTable
        )
        {
            this.CharacterMasterTable = CharacterMasterTable;
        }

        public MemoryDatabase(byte[] databaseBinary, bool internString = true, MessagePack.IFormatterResolver formatterResolver = null, int maxDegreeOfParallelism = 1)
            : base(databaseBinary, internString, formatterResolver, maxDegreeOfParallelism)
        {
        }

        protected override void Init(Dictionary<string, (int offset, int count)> header, System.ReadOnlyMemory<byte> databaseBinary, MessagePack.MessagePackSerializerOptions options, int maxDegreeOfParallelism)
        {
            if(maxDegreeOfParallelism == 1)
            {
                InitSequential(header, databaseBinary, options, maxDegreeOfParallelism);
            }
            else
            {
                InitParallel(header, databaseBinary, options, maxDegreeOfParallelism);
            }
        }

        void InitSequential(Dictionary<string, (int offset, int count)> header, System.ReadOnlyMemory<byte> databaseBinary, MessagePack.MessagePackSerializerOptions options, int maxDegreeOfParallelism)
        {
            this.CharacterMasterTable = ExtractTableData<CharacterMaster, CharacterMasterTable>(header, databaseBinary, options, xs => new CharacterMasterTable(xs));
        }

        void InitParallel(Dictionary<string, (int offset, int count)> header, System.ReadOnlyMemory<byte> databaseBinary, MessagePack.MessagePackSerializerOptions options, int maxDegreeOfParallelism)
        {
            var extracts = new Action[]
            {
                () => this.CharacterMasterTable = ExtractTableData<CharacterMaster, CharacterMasterTable>(header, databaseBinary, options, xs => new CharacterMasterTable(xs)),
            };
            
            System.Threading.Tasks.Parallel.Invoke(new System.Threading.Tasks.ParallelOptions
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism
            }, extracts);
        }

        public ImmutableBuilder ToImmutableBuilder()
        {
            return new ImmutableBuilder(this);
        }

        public DatabaseBuilder ToDatabaseBuilder()
        {
            var builder = new DatabaseBuilder();
            builder.Append(this.CharacterMasterTable.GetRawDataUnsafe());
            return builder;
        }

        public DatabaseBuilder ToDatabaseBuilder(MessagePack.IFormatterResolver resolver)
        {
            var builder = new DatabaseBuilder(resolver);
            builder.Append(this.CharacterMasterTable.GetRawDataUnsafe());
            return builder;
        }

#if !DISABLE_MASTERMEMORY_VALIDATOR

        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            var database = new ValidationDatabase(new object[]
            {
                CharacterMasterTable,
            });

            ((ITableUniqueValidate)CharacterMasterTable).ValidateUnique(result);
            ValidateTable(CharacterMasterTable.All, database, "Code", CharacterMasterTable.PrimaryKeySelector, result);

            return result;
        }

#endif

        static MasterMemory.Meta.MetaDatabase metaTable;

        public static object GetTable(MemoryDatabase db, string tableName)
        {
            switch (tableName)
            {
                case "Character":
                    return db.CharacterMasterTable;
                
                default:
                    return null;
            }
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaDatabase GetMetaDatabase()
        {
            if (metaTable != null) return metaTable;

            var dict = new Dictionary<string, MasterMemory.Meta.MetaTable>();
            dict.Add("Character", Character.Tables.CharacterMasterTable.CreateMetaTable());

            metaTable = new MasterMemory.Meta.MetaDatabase(dict);
            return metaTable;
        }

#endif
    }
}