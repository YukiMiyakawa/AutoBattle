// <auto-generated />
#pragma warning disable CS0105
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;
using Example.Tables;

namespace Example
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

        public void ReplaceAll(System.Collections.Generic.IList<StageMaster> data)
        {
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new StageMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void RemoveStageMaster(string[] keys)
        {
            var data = RemoveCore(memory.StageMasterTable.GetRawDataUnsafe(), keys, x => x.Id, System.StringComparer.Ordinal);
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new StageMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void Diff(StageMaster[] addOrReplaceData)
        {
            var data = DiffCore(memory.StageMasterTable.GetRawDataUnsafe(), addOrReplaceData, x => x.Id, System.StringComparer.Ordinal);
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new StageMasterTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

    }
}