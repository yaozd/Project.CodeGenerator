using System;

namespace Project.CodeGenerator.DBSchema
{
    public class DBSchemaFactory
    {
        static readonly string DatabaseType = "SqlServer";
        public static IDBSchema GetDBSchema()
        {
            IDBSchema dbSchema;
            switch (DatabaseType)
            {
                case "SqlServer":
                    {
                        dbSchema = new SqlServerSchema();
                        break;
                    }
                case "MySql":
                    {
                        dbSchema = new MySqlSchema();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("The input argument of DatabaseType is invalid!");
                    }
            }
            return dbSchema;
        }
    }
}