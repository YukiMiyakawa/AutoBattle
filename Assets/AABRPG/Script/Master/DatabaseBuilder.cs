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
   public sealed class DatabaseBuilder : DatabaseBuilderBase
   {
        public DatabaseBuilder() : this(null) { }
        public DatabaseBuilder(MessagePack.IFormatterResolver resolver) : base(resolver) { }

        public DatabaseBuilder Append(System.Collections.Generic.IEnumerable<StageMaster> dataSource)
        {
            AppendCore(dataSource, x => x.Id, System.StringComparer.Ordinal);
            return this;
        }

    }
}