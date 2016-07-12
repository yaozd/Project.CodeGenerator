using System;
using System.Collections.Generic;

namespace Project.CodeGenerator.DBSchema
{
    public interface IDBSchema : IDisposable
    {
        List<string> GetTablesList();

        Table GetTableMetadata(string tableName);
    }
}