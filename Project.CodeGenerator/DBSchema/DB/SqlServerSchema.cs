using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.CodeGenerator.DBSchema
{
    public class SqlServerSchema : IDBSchema
    {
        public string ConnectionString = "Data Source=.;Initial Catalog=Test1;Persist Security Info=True;User ID=sa;Password=123;";

        public SqlConnection conn;

        public SqlServerSchema()
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
        }

        public List<string> GetTablesList()
        {
            DataTable dt = conn.GetSchema("Tables");
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["TABLE_NAME"].ToString());
            }
            return list;
        }

        public Table GetTableMetadata(string tableName)
        {
            string selectCmdText = string.Format("SELECT * FROM {0}", tableName);
            ;
            SqlCommand command = new SqlCommand(selectCmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(command);
            System.Data.DataSet ds = new DataSet();
            ad.FillSchema(ds, SchemaType.Mapped, tableName);
            Table table = new Table(ds.Tables[0]);
            return table;
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }
    }
}