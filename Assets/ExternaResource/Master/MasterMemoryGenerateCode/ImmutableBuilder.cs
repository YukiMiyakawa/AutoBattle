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
   public sealed class ImmutableBuilder : ImmutableBuilderBase
   {
        MemoryDatabase memory;

        public ImmutableBuilder(MemoryDatabase memory)
        {
            this.memory = memory;
        }

        public MemoryDatabase Build()
        {
            return memory;
        }

        public void ReplaceAll(System.Collections.Generic.IList<CharacterMaster> data)
        {
            var newData = CloneAndSortBy(data, x => x.Code, System.Collections.Generic.Comparer<long>.Default);
            var table = new CharacterMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void RemoveCharacterMaster(long[] keys)
        {
            var data = RemoveCore(memory.CharacterMasterTable.GetRawDataUnsafe(), keys, x => x.Code, System.Collections.Generic.Comparer<long>.Default);
            var newData = CloneAndSortBy(data, x => x.Code, System.Collections.Generic.Comparer<long>.Default);
            var table = new CharacterMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void Diff(CharacterMaster[] addOrReplaceData)
        {
            var data = DiffCore(memory.CharacterMasterTable.GetRawDataUnsafe(), addOrReplaceData, x => x.Code, System.Collections.Generic.Comparer<long>.Default);
            var newData = CloneAndSortBy(data, x => x.Code, System.Collections.Generic.Comparer<long>.Default);
            var table = new CharacterMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

    }
}